var ModuleDesigningPatten;
(function (ModuleDesigningPatten) {
    var student = (function () {
        // keep private function and methods
        var webMethod;
        (function (webMethod) {
            webMethod[webMethod["Get"] = 0] = "Get";
            webMethod[webMethod["Post"] = 1] = "Post";
        })(webMethod || (webMethod = {}));
        function callservice(url, data, method) {
            var dfd = jQuery.Deferred();
            $.ajax({
                url: url,
                method: (method == webMethod.Get) ? "GET" : "POST",
                contentType: "application/json; charset=utf-8",
                data: (method == webMethod.Get) ? data : JSON.stringify(data),
                dataType: "json",
                cache: false,
                success: function (data) {
                    var value = data;
                    dfd.resolve(value);
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(textStatus);
                    dfd.reject();
                }
            });
            return dfd;
        }
        return {
            create: function (item) {
                callservice('/api/create', item, webMethod.Post).done(function (e) {
                    console.log(e);
                });
            },
            readAll: function () {
                callservice('/api/readAll', null, webMethod.Post).done(function (e) {
                    console.log(e);
                });
            },
            readSingle: function (id) {
                callservice('/api/readAll', { id: id }, webMethod.Post).done(function (e) {
                    console.log(e);
                });
            },
            update: function (item) {
                callservice('/api/readAll', { object: item }, webMethod.Post).done(function (e) {
                    console.log(e);
                });
            },
            remove: function (id) {
                callservice('/api/readAll', { id: id }, webMethod.Post).done(function (e) {
                    console.log(e);
                });
            }
        };
    })();
    var Student = (function () {
        function Student(id, name, dob) {
            this.Id = id;
            this.Name = name;
            this.Dob = dob;
        }
        return Student;
    }());
    $(function () {
        student.create(new Student(1, 'Ruwan', new Date(1990, 5, 4)));
        student.readAll();
        student.readSingle(1);
        student.update(new Student(1, 'Madushan', new Date(1990, 5, 4)));
    });
})(ModuleDesigningPatten || (ModuleDesigningPatten = {}));
//# sourceMappingURL=moduleDesigningPatten.js.map