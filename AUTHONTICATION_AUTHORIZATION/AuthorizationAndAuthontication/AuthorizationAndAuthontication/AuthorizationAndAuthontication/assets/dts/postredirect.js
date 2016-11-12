/// <reference path="jquery.d.ts" />
var PostRedirect;
(function (PostRedirect) {
    // See https://github.com/mgalante/jquery.redirect/blob/master/jquery.redirect.js
    function redirect(target, values, method) {
        method = (method && method.toUpperCase() == 'GET') ? 'GET' : 'POST';
        if (!values) {
            var obj = parse_url(target);
            target = obj.url;
            values = obj.params;
        }
        var form = $('<form>', {
            attr: {
                method: method,
                action: target
            }
        });
        for (var i in values) {
            if (Array.isArray(values[i])) {
                for (var j = 0; j < values[i].length; j++) {
                    appendValues(form, i, values[i][j]);
                }
            }
            else {
                appendValues(form, i, values[i]);
            }
        }
        $('body').append(form);
        console.log(form);
        form.submit();
    }
    PostRedirect.redirect = redirect;
    ;
    function appendValues(form, theName, theValue) {
        $('<input>', {
            attr: {
                type: 'hidden',
                name: theName,
                value: theValue
            }
        }).appendTo(form);
    }
    function parse_url(url) {
        if (url.indexOf('?') == -1)
            return { url: url, params: {} };
        var parts = url.split('?');
        var url = parts[0];
        var query_string = parts[1];
        var return_obj = {};
        var elems = query_string.split('&');
        var obj = {};
        for (var i in elems) {
            var elem = elems[i];
            var pair = elem.split('=');
            obj[pair[0]] = pair[1];
        }
        return_obj.url = url;
        return_obj.params = obj;
        return return_obj;
    }
})(PostRedirect || (PostRedirect = {}));
//# sourceMappingURL=postredirect.js.map