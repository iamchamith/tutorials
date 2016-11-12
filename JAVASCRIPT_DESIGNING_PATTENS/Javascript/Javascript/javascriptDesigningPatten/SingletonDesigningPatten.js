var SingltonDesigningPatten;
(function (SingltonDesigningPatten) {
    var connection = (function () {
        var instance;
        function createInstance() {
            instance = new Object("this is connection");
            return instance;
        }
        return {
            getConnection: function () {
                if (instance == null) {
                    instance = createInstance();
                }
                return instance;
            }
        };
    })();
    $(function () {
        var obj1 = connection.getConnection();
        var obj2 = connection.getConnection();
        if (obj1 === obj2) {
            console.log('same');
        }
        else {
            console.log('not same');
        }
    });
})(SingltonDesigningPatten || (SingltonDesigningPatten = {}));
//# sourceMappingURL=SingletonDesigningPatten.js.map