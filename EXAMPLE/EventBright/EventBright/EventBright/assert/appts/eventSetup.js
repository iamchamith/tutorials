var EventSetup;
(function (EventSetup) {
    $(function () {
        init.init();
    });
    var init = {
        init: function () {
            var self = init;
            self.initControles();
            self.lookup();
        },
        initControles: function (e) {
            $('#txtStartDate').kendoDatePicker({ min: new Date() });
            $('#txtEndDate').kendoDatePicker({ min: new Date() });
            $('#txtDescription').kendoEditor();
            $('#event-map').kendoUpload();
            $('#ddCategory').kendoComboBox({ dataTextField: 'text', dataValueField: 'value' });
        },
        lookup: function () {
            new apiConnector().callservice('/api/Events/GetEventCategories', null, webMethod.Get).done(function (e) {
                console.log(e);
            });
        }
    };
    (function (webMethod) {
        webMethod[webMethod["Get"] = 0] = "Get";
        webMethod[webMethod["Post"] = 1] = "Post";
    })(EventSetup.webMethod || (EventSetup.webMethod = {}));
    var webMethod = EventSetup.webMethod;
    var apiConnector = (function () {
        function apiConnector() {
        }
        apiConnector.prototype.callservice = function (url, data, method) {
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
        };
        return apiConnector;
    }());
    EventSetup.apiConnector = apiConnector;
})(EventSetup || (EventSetup = {}));
//# sourceMappingURL=eventSetup.js.map