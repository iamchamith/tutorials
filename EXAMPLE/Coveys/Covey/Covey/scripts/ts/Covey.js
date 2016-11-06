var Time;
(function (Time) {
    var Covey;
    (function (Covey) {
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
        };
    })(Covey = Time.Covey || (Time.Covey = {}));
})(Time || (Time = {}));
