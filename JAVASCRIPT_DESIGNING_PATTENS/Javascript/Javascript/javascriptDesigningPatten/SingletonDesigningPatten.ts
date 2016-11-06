module SingltonDesigningPatten {

    var connection = (function () {

        var instance: any;
        function createInstance() {

            instance = new Object("this is connection");
            return instance;
        }

        return {
            getConnection: () => {

                if (instance == null) {
                    instance = createInstance();
                }
                return instance;
            }
        }

    })();

    $(() => {

        var obj1 = connection.getConnection();
        var obj2 = connection.getConnection();

        if (obj1 === obj2) {
            console.log('same');
        } else {
            console.log('not same');
        }
    });
}