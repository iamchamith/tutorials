module EventSetup {

    $(() => {

        init.init();
    });

    var init = {
  
        init: () => {
            var self = init;
            self.initControles();
            self.lookup();
        },
        initControles: (e?) => {
            $('#txtStartDate').kendoDatePicker({ min: new Date() });
            $('#txtEndDate').kendoDatePicker({ min: new Date() });
            $('#txtDescription').kendoEditor();
            $('#event-map').kendoUpload();
            $('#ddCategory').kendoComboBox({ dataTextField: 'text', dataValueField: 'value' });
        },
        lookup: () => {
            new apiConnector().callservice('/api/Events/GetEventCategories', null, webMethod.Get).done((e) => {

                console.log(e);
            });
        }
       

    }
    export enum webMethod {
        Get = 0,
        Post = 1
    }

    export class apiConnector {

        callservice(url: string, data: any, method: webMethod): JQueryDeferred<any> {
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
    }
}