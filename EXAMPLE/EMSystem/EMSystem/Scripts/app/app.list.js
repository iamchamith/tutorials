var app = {
    init() {
        this.renderEmployee();
    },
    renderEmployee(e) {
        var self = this;
        var datatableTabletools = undefined;
        self.tblEmployee = $('#tblEmployee').DataTable({
           // sDom: '<"top"i>rt<"bottom"flp><"clear">',
            iDisplayLength: -1,
            info: true,
            autoWidth: true,
            paging: false,
            order: [],
            mark: true,
            scrollY: 300,
            preDrawCallback: function () {
                if (!datatableTabletools) {
                    datatableTabletools = new ResponsiveDatatablesHelper($('#tblEmployee'), { tablet: 1024, phone: 480 });
                }
            },
            rowCallback: function (e) {
                datatableTabletools.createExpandIcon(e);
            },
            drawCallback: function (e) {
                datatableTabletools.respond();
            },
            ajax: {
                url: '/home/getemployees',
                dataType: 'json',
                dataSrc: "employees"
            },
            columns: [
                { data: "fullName" },
                { data: "division" },
                { data: "office" },
                { data: "position" },
                { data: "period" },
                { data: "salary" },
                { data: null }
            ],
            columnDefs: [
                {
                    targets: 6,
                    render: function (data, type, row) {
                        return '<button class=\'btn btn-xs btn-default\')><i class=\'fa fa-trash text-danger\' ></i></button>'
                    }
                }
            ],
            initComplete: function (settings, json) {
                $('#tblEmployee tbody').off('click').on('click', 'button', self.onDeleteClick.bind(self));
                $('#tblEmployee tbody').on('click', 'tr td:first-child', self.onEditClick.bind(self));
            }
        });
    },
    onDeleteClick(e) {
        var self = this;
        var data = self.tblEmployee.row($(e.target).parents('tr')).data();
        if (window.confirm("Are you sure you want to delete this employee (" + data.fullName +")?")) {
            $.ajax('/home/deleteajax', {
                type: "POST",
                data: { employee: data },
                success: () => {
                    self.tblEmployee.ajax.reload(null, false);
                }
            })
        }
    },
    onEditClick(e) {
        var data = this.tblEmployee.row($(e.target).parents('tr')).data();
        $(location).attr("href", "/home/detail?empId=" + data.id);
    }
}
$(() => {
    app.init();
});