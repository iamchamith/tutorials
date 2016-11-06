module ModuleDesigningPatten {

    var student = (function () {

        // keep private function and methods

        enum webMethod {
            Get = 0,
            Post = 1
        }

        function callservice(url: string, data: any, method: webMethod): JQueryDeferred<any> {
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

            create: (item: Student) => {
                callservice('/api/create', item, webMethod.Post).done((e) => {
                    console.log(e);
                });

            },
            readAll: () => {
                callservice('/api/readAll', null, webMethod.Post).done((e) => {
                    console.log(e);
                });
            },
            readSingle: (id: Number) => {
                callservice('/api/readAll', { id: id }, webMethod.Post).done((e) => {
                    console.log(e);
                });
            },
            update: (item: Student) => {
                callservice('/api/readAll', { object: item }, webMethod.Post).done((e) => {
                    console.log(e);
                });
            },
            remove: (id: Number) => {
                callservice('/api/readAll', { id: id }, webMethod.Post).done((e) => {
                    console.log(e);
                });
            }

        }

    })();


    class Student {
        Id: number;
        Name: string;
        Dob: Date

        constructor(id, name, dob) {
            this.Id = id;
            this.Name = name;
            this.Dob = dob;
        }
    }

    $(() => {
        student.create(new Student(1, 'Ruwan', new Date(1990, 5, 4)));
        student.readAll();
        student.readSingle(1);
        student.update(new Student(1, 'Madushan', new Date(1990, 5, 4)));
    });
}