﻿(function (globals) {
    "use strict";

    Bridge.define('Test.BridgeIssues.N1151.renderTarget', {
        constructor: function (gl, w, h, nCmp) {
            /* **************************************************************************/
            /*  ACCORDING TO SOME EXAMPLES, WE DONT NEED RENDERBUFFER STORAGE FOR RENDER
                /* TO TEXTURE ON THE COLOR CHANNEL * gl.bindRenderBuffer(gl.RENDERBUFFER,
                /* this.colorRenderBuffer); gl.RenderBufferStorage(gl.RENDERBUFFER,
                /* this.internalFormat, this.width, this.height); /
                **************************************************************************/
            var i = 0;
            i = (i + 1) | 0;
        }
    });
    
    
    
    Bridge.init();
})(this);
