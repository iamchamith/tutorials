//module Master {

//    $(() => {

//        initPage();



//    });


//    function initPage() {

//        $('grid').kendoGrid({
//            columns: [{
//                {title: '', field:'' }
//            }]
//        });

        
//    }

//    var emp =  (function () {

//        const baseUrl = "";
//        function apiConnector(action: string, data: any, method: string) {

//            var defer = $.Deferred();
//            $.ajax({
//                url: baseUrl + action, data: data, method: method,
//                success: (e) => { defer.resolve(e) }
//            });
//            return defer;

//        }
         
//        return {
//            create: (e?) => {
//                var data = {}
//                apiConnector('', data, 'post').done((e) => {
//                    console.log();
//                });

//            },
//            update: (e?) => {
//                var data = {}
//                apiConnector('', data, 'post').done((e) => {
//                    console.log();
//                });
//            },
//            delete: (e?) => {
//                var data = {}
//                apiConnector('', data, 'post').done((e) => {
//                    console.log();
//                });
//            },
//            read: (e?) => {
//                var data = {}
//                apiConnector('', data, 'post').done((e) => {
//                    console.log();
//                });
//            },
//            readAll: (e?) => {
//                var data = {}
//                apiConnector('', data, 'post').done((e) => {
//                    console.log();
//                });
//            },
//            search: (e?) => {
//                var data = {}
//                apiConnector('', data, 'post').done((e) => {
//                    console.log();
//                });
//            }
//        }

//    })();

//}