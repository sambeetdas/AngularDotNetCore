"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DmAuthGuard = /** @class */ (function () {
    function DmAuthGuard(_router, _util) {
        this._router = _router;
        this._util = _util;
    }
    DmAuthGuard.prototype.canActivate = function () {
        if (this._util.IsLoggedin())
            return true;
        else {
            this._router.navigate(['/login']);
            return false;
        }
    };
    return DmAuthGuard;
}());
exports.DmAuthGuard = DmAuthGuard;
//# sourceMappingURL=dmauthguard.js.map