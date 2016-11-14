module TownSuite.Signatures {

    export class Pad {
        signaturePad: SignaturePad;
        id: string;

        constructor(canvasId: string) {
            let canvas = <HTMLCanvasElement>document.getElementById(canvasId);
            this.id = canvasId;
            // Adjust canvas coordinate space taking into account pixel ratio,
            // to make it look crisp on mobile devices.
            // This also causes canvas to be cleared.
            function resizeCanvas() {
                // When zoomed out to less than 100%, for some very strange reason,
                // some browsers report devicePixelRatio as less than 1
                // and only part of the canvas is cleared then.
                let ratio = Math.max(window.devicePixelRatio || 1, 1);
                canvas.width = canvas.offsetWidth * ratio;
                canvas.height = canvas.offsetHeight * ratio;
                canvas.getContext("2d").scale(ratio, ratio);
            }

            //window.onresize = resizeCanvas;
            resizeCanvas();
            this.signaturePad = new SignaturePad(canvas);
        }

        public toDataURL(): string {
            return this.signaturePad._canvas.toDataURL("image/png", 0.1);
        }

        public toDataURLWithMarkup(): string {
            return '<img src="' + this.signaturePad._canvas.toDataURL("image/png", 0.1) + '" />';
        }

        public isEmpty(): boolean {
            return this.signaturePad.isEmpty();
        }

        public onEnd(callback: () => void) {
            this.signaturePad.onEnd = callback;
        }

        public clear() {
            this.signaturePad.clear();
        }

        public focus() {
            this.cursorFocus(document.getElementById(this.id));
            this.animate();
        }

        animate() {
            $('#' + this.id).removeClass()
                .addClass('bounceIn animated')
                .one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                    $(this).removeClass();
                });
        }

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

        cursorFocus(elem: HTMLElement) {
            var x = window.scrollX, y = window.scrollY;
            elem.focus();
            window.scrollTo(x, y + 100);
        }
        /*
        //name: Hermite resize
        //about: Fast image resize/resample using Hermite filter with JavaScript.
        //author: ViliusL
        //demo: http://viliusle.github.io/miniPaint/
        resample_hermite(canvas: HTMLCanvasElement, W: number, H: number, W2: number, H2: number) {
            var time1 = Date.now();
            W2 = Math.round(W2);
            H2 = Math.round(H2);
            var img = canvas.getContext("2d").getImageData(0, 0, W, H);
            var img2 = canvas.getContext("2d").getImageData(0, 0, W2, H2);
            var data = img.data;
            var data2 = img2.data;
            var ratio_w = W / W2;
            var ratio_h = H / H2;
            var ratio_w_half = Math.ceil(ratio_w / 2);
            var ratio_h_half = Math.ceil(ratio_h / 2);

            let gx_g;
            let gx_b;
            let gx_a
            for (var j = 0; j < H2; j++) {
                for (var i = 0; i < W2; i++) {
                    var x2 = (i + j * W2) * 4;
                    var weight = 0;
                    var weights = 0;
                    var weights_alpha = 0;
                    var gx_r = gx_g = gx_b = gx_a = 0;
                    var center_y = (j + 0.5) * ratio_h;
                    for (var yy = Math.floor(j * ratio_h); yy < (j + 1) * ratio_h; yy++) {
                        var dy = Math.abs(center_y - (yy + 0.5)) / ratio_h_half;
                        var center_x = (i + 0.5) * ratio_w;
                        var w0 = dy * dy //pre-calc part of w
                        for (var xx = Math.floor(i * ratio_w); xx < (i + 1) * ratio_w; xx++) {
                            var dx = Math.abs(center_x - (xx + 0.5)) / ratio_w_half;
                            var w = Math.sqrt(w0 + dx * dx);
                            if (w >= -1 && w <= 1) {
                                //hermite filter
                                weight = 2 * w * w * w - 3 * w * w + 1;
                                if (weight > 0) {
                                    dx = 4 * (xx + yy * W);
                                    //alpha
                                    gx_a += weight * data[dx + 3];
                                    weights_alpha += weight;
                                    //colors
                                    if (data[dx + 3] < 255)
                                        weight = weight * data[dx + 3] / 250;
                                    gx_r += weight * data[dx];
                                    gx_g += weight * data[dx + 1];
                                    gx_b += weight * data[dx + 2];
                                    weights += weight;
                                }
                            }
                        }
                    }
                    data2[x2] = gx_r / weights;
                    data2[x2 + 1] = gx_g / weights;
                    data2[x2 + 2] = gx_b / weights;
                    data2[x2 + 3] = gx_a / weights_alpha;
                }
            }
            //console.log("hermite = " + (Math.round(Date.now() - time1) / 1000) + " s");
            canvas.getContext("2d").clearRect(0, 0, Math.max(W, W2), Math.max(H, H2));
            canvas.width = W2;
            canvas.height = H2;
            canvas.getContext("2d").putImageData(img2, 0, 0);
        }
        */
    }
}