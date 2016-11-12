var TownSuite;
(function (TownSuite) {
    var Signatures;
    (function (Signatures) {
        var Pad = (function () {
            function Pad(canvasId) {
                var canvas = document.getElementById(canvasId);
                this.id = canvasId;
                // Adjust canvas coordinate space taking into account pixel ratio,
                // to make it look crisp on mobile devices.
                // This also causes canvas to be cleared.
                function resizeCanvas() {
                    // When zoomed out to less than 100%, for some very strange reason,
                    // some browsers report devicePixelRatio as less than 1
                    // and only part of the canvas is cleared then.
                    var ratio = Math.max(window.devicePixelRatio || 1, 1);
                    canvas.width = canvas.offsetWidth * ratio;
                    canvas.height = canvas.offsetHeight * ratio;
                    canvas.getContext("2d").scale(ratio, ratio);
                }
                //window.onresize = resizeCanvas;
                resizeCanvas();
                this.signaturePad = new SignaturePad(canvas);
            }
            Pad.prototype.toDataURL = function () {
                return this.signaturePad._canvas.toDataURL("image/png", 0.1);
            };
            Pad.prototype.toDataURLWithMarkup = function () {
                return '<img src="' + this.signaturePad._canvas.toDataURL("image/png", 0.1) + '" />';
            };
            Pad.prototype.isEmpty = function () {
                return this.signaturePad.isEmpty();
            };
            Pad.prototype.onEnd = function (callback) {
                this.signaturePad.onEnd = callback;
            };
            Pad.prototype.clear = function () {
                this.signaturePad.clear();
            };
            Pad.prototype.focus = function () {
                this.cursorFocus(document.getElementById(this.id));
                this.animate();
            };
            Pad.prototype.animate = function () {
                $('#' + this.id).removeClass()
                    .addClass('bounceIn animated')
                    .one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                    $(this).removeClass();
                });
            };
            //resizeImage(width: number): string {
            //    let canvasCopy = <HTMLCanvasElement>document.createElement("canvas");
            //    let copyContext = canvasCopy.getContext("2d");
            //    canvasCopy.width = width;
            //    canvasCopy.height = this.signaturePad._canvas.height;
            //    copyContext.drawImage(this.signaturePad._canvas, 0, 0, canvasCopy.width, canvasCopy.height);
            //    //canvasCopy.width = 400;
            //    //this.resample_hermite(canvasCopy, canvasCopy.width, canvasCopy.height, 400, 200);
            //    return canvasCopy.toDataURL("image/png", 0.1);
            //}
            Pad.prototype.cursorFocus = function (elem) {
                var x = window.scrollX, y = window.scrollY;
                elem.focus();
                window.scrollTo(x, y + 100);
            };
            return Pad;
        }());
        Signatures.Pad = Pad;
    })(Signatures = TownSuite.Signatures || (TownSuite.Signatures = {}));
})(TownSuite || (TownSuite = {}));
//# sourceMappingURL=eSignature.js.map