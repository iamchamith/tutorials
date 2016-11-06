module Time.Covey {

    $(function () {


    });

    var init = {

        initControlles: function () {

            $("#grid").kendoGrid({
                columns: [
                    { field: "name" },
                    { field: "age" }
                ],
                dataSource: [
                    { name: "Jane Doe", age: 30 },
                    { name: "John Doe", age: 33 }
                ],
                editable: true
            });
        }
    }
}