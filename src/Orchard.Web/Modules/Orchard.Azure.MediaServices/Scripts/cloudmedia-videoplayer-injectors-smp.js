/*
** NOTE: This file is generated by Gulp and should not be edited directly!
** Any changes made directly to this file will be overwritten next time its asset group is processed by Gulp.
*/

/// <reference path="Typings/jquery.d.ts" />
/// <reference path="Typings/underscore.d.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Orchard;
(function (Orchard) {
    var Azure;
    (function (Azure) {
        var MediaServices;
        (function (MediaServices) {
            var VideoPlayer;
            (function (VideoPlayer) {
                var Injectors;
                (function (Injectors) {
                    Injectors.instances = new Array();
                    var SmpInjector = (function (_super) {
                        __extends(SmpInjector, _super);
                        function SmpInjector(container, playerWidth, playerHeight, autoPlay, assetData, applyMediaQueries, debugToConsole, nextInjector, contentBaseUrl) {
                            _super.call(this, container, playerWidth, playerHeight, autoPlay, assetData, applyMediaQueries, debugToConsole, nextInjector);
                            this.contentBaseUrl = contentBaseUrl;
                            this.flashVersion = "10.2.0";
                            this.innerElementId = container.id + "-inner";
                        }
                        SmpInjector.prototype.isSupported = function () {
                            var browserHasFlash = swfobject.hasFlashPlayerVersion(this.flashVersion);
                            var hasDynamicAssets = _(this.filteredAssets().DynamicVideoAssets).any();
                            var result = browserHasFlash && hasDynamicAssets;
                            this.debug("Browser has required Flash version: {0}", browserHasFlash);
                            this.debug("Item has at least one dynamic video asset: {0}", hasDynamicAssets);
                            this.debug("isSupported() returns {0}.", result);
                            return result;
                        };
                        SmpInjector.prototype.inject = function () {
                            var _this = this;
                            var firstDynamicAsset = _(this.filteredAssets().DynamicVideoAssets).first();
                            var firstThumbnailAsset = _(this.filteredAssets().ThumbnailAssets).first();
                            var flashvars = {
                                src: firstDynamicAsset.SmoothStreamingUrl,
                                plugin_AdaptiveStreamingPlugin: encodeURIComponent(this.contentBaseUrl + "MSAdaptiveStreamingPlugin.swf"),
                                AdaptiveStreamingPlugin_retryLive: "true",
                                AdaptiveStreamingPlugin_retryInterval: "10",
                                autoPlay: this.autoPlay.toString(),
                                bufferingOverlay: "false",
                                poster: firstThumbnailAsset ? encodeURIComponent(firstThumbnailAsset.MainFileUrl) : null,
                                javascriptCallbackFunction: "Orchard.Azure.MediaServices.VideoPlayer.Injectors.onSmpBridgeCreated"
                            };
                            var params = {
                                allowFullScreen: "true",
                                allowScriptAccess: "always",
                                wmode: "direct"
                            };
                            var attributes = {
                                id: this.innerElementId
                            };
                            $("<div>").attr("id", this.innerElementId).appendTo(this.container);
                            this.debug("Injecting player into element '{0}'.", this.container.id);
                            swfobject.embedSWF(this.contentBaseUrl + "StrobeMediaPlayback.swf", this.innerElementId, this.playerWidth.toString(), this.playerHeight.toString(), this.flashVersion, this.contentBaseUrl + "expressInstall.swf", flashvars, params, attributes, function (e) {
                                if (!e.success)
                                    _this.fault();
                            });
                            Injectors.instances[this.innerElementId] = this;
                        };
                        SmpInjector.prototype.onMediaPlayerStateChange = function (state) {
                            if (state == "playbackError") {
                                this.debug("Playback error detected; cleaning up container and faulting this injector.");
                                Injectors.instances[this.innerElementId] = null;
                                this.fault();
                            }
                        };
                        SmpInjector.prototype.debug = function (message) {
                            var args = [];
                            for (var _i = 1; _i < arguments.length; _i++) {
                                args[_i - 1] = arguments[_i];
                            }
                            _super.prototype.debug.call(this, "SmpInjector: " + message, args);
                        };
                        return SmpInjector;
                    })(Injectors.Injector);
                    Injectors.SmpInjector = SmpInjector;
                    function onSmpBridgeCreated(playerElementId) {
                        var player = document.getElementById(playerElementId);
                        if (player) {
                            player.addEventListener("mediaPlayerStateChange", "Orchard.Azure.MediaServices.VideoPlayer.Injectors.instances[\"" + playerElementId + "\"].onMediaPlayerStateChange");
                        }
                    }
                    Injectors.onSmpBridgeCreated = onSmpBridgeCreated;
                })(Injectors = VideoPlayer.Injectors || (VideoPlayer.Injectors = {}));
            })(VideoPlayer = MediaServices.VideoPlayer || (MediaServices.VideoPlayer = {}));
        })(MediaServices = Azure.MediaServices || (Azure.MediaServices = {}));
    })(Azure = Orchard.Azure || (Orchard.Azure = {}));
})(Orchard || (Orchard = {}));

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImNsb3VkbWVkaWEtdmlkZW9wbGF5ZXItaW5qZWN0b3JzLXNtcC5qcyIsImNsb3VkbWVkaWEtdmlkZW9wbGF5ZXItaW5qZWN0b3JzLXNtcC50cyJdLCJuYW1lcyI6WyJPcmNoYXJkIiwiT3JjaGFyZC5BenVyZSIsIk9yY2hhcmQuQXp1cmUuTWVkaWFTZXJ2aWNlcyIsIk9yY2hhcmQuQXp1cmUuTWVkaWFTZXJ2aWNlcy5WaWRlb1BsYXllciIsIk9yY2hhcmQuQXp1cmUuTWVkaWFTZXJ2aWNlcy5WaWRlb1BsYXllci5JbmplY3RvcnMiLCJPcmNoYXJkLkF6dXJlLk1lZGlhU2VydmljZXMuVmlkZW9QbGF5ZXIuSW5qZWN0b3JzLlNtcEluamVjdG9yIiwiT3JjaGFyZC5BenVyZS5NZWRpYVNlcnZpY2VzLlZpZGVvUGxheWVyLkluamVjdG9ycy5TbXBJbmplY3Rvci5jb25zdHJ1Y3RvciIsIk9yY2hhcmQuQXp1cmUuTWVkaWFTZXJ2aWNlcy5WaWRlb1BsYXllci5JbmplY3RvcnMuU21wSW5qZWN0b3IuaXNTdXBwb3J0ZWQiLCJPcmNoYXJkLkF6dXJlLk1lZGlhU2VydmljZXMuVmlkZW9QbGF5ZXIuSW5qZWN0b3JzLlNtcEluamVjdG9yLmluamVjdCIsIk9yY2hhcmQuQXp1cmUuTWVkaWFTZXJ2aWNlcy5WaWRlb1BsYXllci5JbmplY3RvcnMuU21wSW5qZWN0b3Iub25NZWRpYVBsYXllclN0YXRlQ2hhbmdlIiwiT3JjaGFyZC5BenVyZS5NZWRpYVNlcnZpY2VzLlZpZGVvUGxheWVyLkluamVjdG9ycy5TbXBJbmplY3Rvci5kZWJ1ZyIsIk9yY2hhcmQuQXp1cmUuTWVkaWFTZXJ2aWNlcy5WaWRlb1BsYXllci5JbmplY3RvcnMub25TbXBCcmlkZ2VDcmVhdGVkIl0sIm1hcHBpbmdzIjoiQUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsQUNMQSw0Q0FBNEM7QUFDNUMsZ0RBQWdEOzs7Ozs7QUFFaEQsSUFBTyxPQUFPLENBd0diO0FBeEdELFdBQU8sT0FBTztJQUFD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LHFCQUFTQSxLQUFUQSxxQkFBU0EsUUF3R3ZEQTtZQUFEQSxDQUFDQSxFQXhHa0NELFdBQVdBLEdBQVhBLHlCQUFXQSxLQUFYQSx5QkFBV0EsUUF3RzdDQTtRQUFEQSxDQUFDQSxFQXhHb0JELGFBQWFBLEdBQWJBLG1CQUFhQSxLQUFiQSxtQkFBYUEsUUF3R2pDQTtJQUFEQSxDQUFDQSxFQXhHY0QsS0FBS0EsR0FBTEEsYUFBS0EsS0FBTEEsYUFBS0EsUUF3R25CQTtBQUFEQSxDQUFDQSxFQXhHTSxPQUFPLEtBQVAsT0FBTyxRQXdHYiIsImZpbGUiOiJjbG91ZG1lZGlhLXZpZGVvcGxheWVyLWluamVjdG9ycy1zbXAuanMiLCJzb3VyY2VzQ29udGVudCI6W251bGwsIi8vLyA8cmVmZXJlbmNlIHBhdGg9XCJUeXBpbmdzL2pxdWVyeS5kLnRzXCIgLz5cbi8vLyA8cmVmZXJlbmNlIHBhdGg9XCJUeXBpbmdzL3VuZGVyc2NvcmUuZC50c1wiIC8+XG5cbm1vZHVsZSBPcmNoYXJkLkF6dXJlLk1lZGlhU2VydmljZXMuVmlkZW9QbGF5ZXIuSW5qZWN0b3JzIHtcblxuICAgIGltcG9ydCBEYXRhID0gT3JjaGFyZC5BenVyZS5NZWRpYVNlcnZpY2VzLlZpZGVvUGxheWVyLkRhdGE7XG5cbiAgICBkZWNsYXJlIHZhciBzd2ZvYmplY3Q6IGFueTtcblxuICAgIGV4cG9ydCB2YXIgaW5zdGFuY2VzOiBTbXBJbmplY3RvcltdID0gbmV3IEFycmF5KCk7XG5cbiAgICBleHBvcnQgY2xhc3MgU21wSW5qZWN0b3IgZXh0ZW5kcyBJbmplY3RvciB7XG5cbiAgICAgICAgcHJpdmF0ZSBmbGFzaFZlcnNpb24gPSBcIjEwLjIuMFwiO1xuICAgICAgICBwcml2YXRlIGlubmVyRWxlbWVudElkOiBzdHJpbmc7XG5cbiAgICAgICAgY29uc3RydWN0b3IoXG4gICAgICAgICAgICBjb250YWluZXI6IEhUTUxFbGVtZW50LFxuICAgICAgICAgICAgcGxheWVyV2lkdGg6IG51bWJlcixcbiAgICAgICAgICAgIHBsYXllckhlaWdodDogbnVtYmVyLFxuICAgICAgICAgICAgYXV0b1BsYXk6IGJvb2xlYW4sXG4gICAgICAgICAgICBhc3NldERhdGE6IERhdGEuSUFzc2V0RGF0YSxcbiAgICAgICAgICAgIGFwcGx5TWVkaWFRdWVyaWVzOiBib29sZWFuLFxuICAgICAgICAgICAgZGVidWdUb0NvbnNvbGU6IGJvb2xlYW4sXG4gICAgICAgICAgICBuZXh0SW5qZWN0b3I6IEluamVjdG9yLFxuICAgICAgICAgICAgcHJpdmF0ZSBjb250ZW50QmFzZVVybDogc3RyaW5nKSB7XG4gICAgICAgICAgICBzdXBlcihjb250YWluZXIsIHBsYXllcldpZHRoLCBwbGF5ZXJIZWlnaHQsIGF1dG9QbGF5LCBhc3NldERhdGEsIGFwcGx5TWVkaWFRdWVyaWVzLCBkZWJ1Z1RvQ29uc29sZSwgbmV4dEluamVjdG9yKTtcbiAgICAgICAgICAgIHRoaXMuaW5uZXJFbGVtZW50SWQgPSBjb250YWluZXIuaWQgKyBcIi1pbm5lclwiO1xuICAgICAgICB9XG5cbiAgICAgICAgcHVibGljIGlzU3VwcG9ydGVkKCk6IGJvb2xlYW4ge1xuICAgICAgICAgICAgdmFyIGJyb3dzZXJIYXNGbGFzaCA9IHN3Zm9iamVjdC5oYXNGbGFzaFBsYXllclZlcnNpb24odGhpcy5mbGFzaFZlcnNpb24pO1xuICAgICAgICAgICAgdmFyIGhhc0R5bmFtaWNBc3NldHMgPSBfKHRoaXMuZmlsdGVyZWRBc3NldHMoKS5EeW5hbWljVmlkZW9Bc3NldHMpLmFueSgpO1xuICAgICAgICAgICAgdmFyIHJlc3VsdCA9IGJyb3dzZXJIYXNGbGFzaCAmJiBoYXNEeW5hbWljQXNzZXRzO1xuXG4gICAgICAgICAgICB0aGlzLmRlYnVnKFwiQnJvd3NlciBoYXMgcmVxdWlyZWQgRmxhc2ggdmVyc2lvbjogezB9XCIsIGJyb3dzZXJIYXNGbGFzaCk7XG4gICAgICAgICAgICB0aGlzLmRlYnVnKFwiSXRlbSBoYXMgYXQgbGVhc3Qgb25lIGR5bmFtaWMgdmlkZW8gYXNzZXQ6IHswfVwiLCBoYXNEeW5hbWljQXNzZXRzKTtcblxuICAgICAgICAgICAgdGhpcy5kZWJ1ZyhcImlzU3VwcG9ydGVkKCkgcmV0dXJucyB7MH0uXCIsIHJlc3VsdCk7XG4gICAgICAgICAgICByZXR1cm4gcmVzdWx0O1xuICAgICAgICB9XG5cbiAgICAgICAgcHVibGljIGluamVjdCgpOiB2b2lkIHtcbiAgICAgICAgICAgIHZhciBmaXJzdER5bmFtaWNBc3NldCA9IF8odGhpcy5maWx0ZXJlZEFzc2V0cygpLkR5bmFtaWNWaWRlb0Fzc2V0cykuZmlyc3QoKTtcbiAgICAgICAgICAgIHZhciBmaXJzdFRodW1ibmFpbEFzc2V0ID0gXyh0aGlzLmZpbHRlcmVkQXNzZXRzKCkuVGh1bWJuYWlsQXNzZXRzKS5maXJzdCgpO1xuXG4gICAgICAgICAgICB2YXIgZmxhc2h2YXJzID0ge1xuICAgICAgICAgICAgICAgIHNyYzogZmlyc3REeW5hbWljQXNzZXQuU21vb3RoU3RyZWFtaW5nVXJsLFxuICAgICAgICAgICAgICAgIHBsdWdpbl9BZGFwdGl2ZVN0cmVhbWluZ1BsdWdpbjogZW5jb2RlVVJJQ29tcG9uZW50KHRoaXMuY29udGVudEJhc2VVcmwgKyBcIk1TQWRhcHRpdmVTdHJlYW1pbmdQbHVnaW4uc3dmXCIpLFxuICAgICAgICAgICAgICAgIEFkYXB0aXZlU3RyZWFtaW5nUGx1Z2luX3JldHJ5TGl2ZTogXCJ0cnVlXCIsXG4gICAgICAgICAgICAgICAgQWRhcHRpdmVTdHJlYW1pbmdQbHVnaW5fcmV0cnlJbnRlcnZhbDogXCIxMFwiLFxuICAgICAgICAgICAgICAgIGF1dG9QbGF5OiB0aGlzLmF1dG9QbGF5LnRvU3RyaW5nKCksXG4gICAgICAgICAgICAgICAgYnVmZmVyaW5nT3ZlcmxheTogXCJmYWxzZVwiLFxuICAgICAgICAgICAgICAgIHBvc3RlcjogZmlyc3RUaHVtYm5haWxBc3NldCA/IGVuY29kZVVSSUNvbXBvbmVudChmaXJzdFRodW1ibmFpbEFzc2V0Lk1haW5GaWxlVXJsKSA6IG51bGwsXG4gICAgICAgICAgICAgICAgamF2YXNjcmlwdENhbGxiYWNrRnVuY3Rpb246IFwiT3JjaGFyZC5BenVyZS5NZWRpYVNlcnZpY2VzLlZpZGVvUGxheWVyLkluamVjdG9ycy5vblNtcEJyaWRnZUNyZWF0ZWRcIlxuICAgICAgICAgICAgfTtcbiAgICAgICAgICAgICBcbiAgICAgICAgICAgIHZhciBwYXJhbXMgPSB7XG4gICAgICAgICAgICAgICAgYWxsb3dGdWxsU2NyZWVuOiBcInRydWVcIixcbiAgICAgICAgICAgICAgICBhbGxvd1NjcmlwdEFjY2VzczogXCJhbHdheXNcIixcbiAgICAgICAgICAgICAgICB3bW9kZTogXCJkaXJlY3RcIlxuICAgICAgICAgICAgfTtcblxuICAgICAgICAgICAgdmFyIGF0dHJpYnV0ZXMgPSB7XG4gICAgICAgICAgICAgICAgaWQ6IHRoaXMuaW5uZXJFbGVtZW50SWRcbiAgICAgICAgICAgIH07XG5cbiAgICAgICAgICAgICQoXCI8ZGl2PlwiKS5hdHRyKFwiaWRcIiwgdGhpcy5pbm5lckVsZW1lbnRJZCkuYXBwZW5kVG8odGhpcy5jb250YWluZXIpO1xuICAgICAgICAgICAgdGhpcy5kZWJ1ZyhcIkluamVjdGluZyBwbGF5ZXIgaW50byBlbGVtZW50ICd7MH0nLlwiLCB0aGlzLmNvbnRhaW5lci5pZCk7XG5cbiAgICAgICAgICAgIHN3Zm9iamVjdC5lbWJlZFNXRihcbiAgICAgICAgICAgICAgICB0aGlzLmNvbnRlbnRCYXNlVXJsICsgXCJTdHJvYmVNZWRpYVBsYXliYWNrLnN3ZlwiLFxuICAgICAgICAgICAgICAgIHRoaXMuaW5uZXJFbGVtZW50SWQsXG4gICAgICAgICAgICAgICAgdGhpcy5wbGF5ZXJXaWR0aC50b1N0cmluZygpLFxuICAgICAgICAgICAgICAgIHRoaXMucGxheWVySGVpZ2h0LnRvU3RyaW5nKCksXG4gICAgICAgICAgICAgICAgdGhpcy5mbGFzaFZlcnNpb24sXG4gICAgICAgICAgICAgICAgdGhpcy5jb250ZW50QmFzZVVybCArIFwiZXhwcmVzc0luc3RhbGwuc3dmXCIsXG4gICAgICAgICAgICAgICAgZmxhc2h2YXJzLFxuICAgICAgICAgICAgICAgIHBhcmFtcyxcbiAgICAgICAgICAgICAgICBhdHRyaWJ1dGVzLFxuICAgICAgICAgICAgICAgIChlOiBhbnkpID0+IHtcbiAgICAgICAgICAgICAgICAgICAgaWYgKCFlLnN1Y2Nlc3MpXG4gICAgICAgICAgICAgICAgICAgICAgICB0aGlzLmZhdWx0KCk7XG4gICAgICAgICAgICAgICAgfSk7XG5cbiAgICAgICAgICAgICg8YW55Pmluc3RhbmNlcylbdGhpcy5pbm5lckVsZW1lbnRJZF0gPSB0aGlzO1xuICAgICAgICB9XG4gICAgICAgICBcbiAgICAgICAgcHVibGljIG9uTWVkaWFQbGF5ZXJTdGF0ZUNoYW5nZShzdGF0ZTogc3RyaW5nKSB7XG4gICAgICAgICAgICBpZiAoc3RhdGUgPT0gXCJwbGF5YmFja0Vycm9yXCIpIHtcbiAgICAgICAgICAgICAgICB0aGlzLmRlYnVnKFwiUGxheWJhY2sgZXJyb3IgZGV0ZWN0ZWQ7IGNsZWFuaW5nIHVwIGNvbnRhaW5lciBhbmQgZmF1bHRpbmcgdGhpcyBpbmplY3Rvci5cIik7XG4gICAgICAgICAgICAgICAgKDxhbnk+aW5zdGFuY2VzKVt0aGlzLmlubmVyRWxlbWVudElkXSA9IG51bGw7XG4gICAgICAgICAgICAgICAgdGhpcy5mYXVsdCgpO1xuICAgICAgICAgICAgfVxuICAgICAgICB9XG5cbiAgICAgICAgcHVibGljIGRlYnVnKG1lc3NhZ2U6IHN0cmluZywgLi4uYXJnczogYW55W10pOiB2b2lkIHtcbiAgICAgICAgICAgIHN1cGVyLmRlYnVnKFwiU21wSW5qZWN0b3I6IFwiICsgbWVzc2FnZSwgYXJncyk7XG4gICAgICAgIH1cbiAgICB9XG4gICAgIFxuICAgIGV4cG9ydCBmdW5jdGlvbiBvblNtcEJyaWRnZUNyZWF0ZWQocGxheWVyRWxlbWVudElkOiBzdHJpbmcpIHtcbiAgICAgICAgdmFyIHBsYXllciA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKHBsYXllckVsZW1lbnRJZCk7XG4gICAgICAgIGlmIChwbGF5ZXIpIHtcbiAgICAgICAgICAgICg8YW55PnBsYXllcikuYWRkRXZlbnRMaXN0ZW5lcihcIm1lZGlhUGxheWVyU3RhdGVDaGFuZ2VcIiwgXCJPcmNoYXJkLkF6dXJlLk1lZGlhU2VydmljZXMuVmlkZW9QbGF5ZXIuSW5qZWN0b3JzLmluc3RhbmNlc1tcXFwiXCIgKyBwbGF5ZXJFbGVtZW50SWQgKyBcIlxcXCJdLm9uTWVkaWFQbGF5ZXJTdGF0ZUNoYW5nZVwiKTtcbiAgICAgICAgfVxuICAgIH0gXG59Il0sInNvdXJjZVJvb3QiOiIvc291cmNlLyJ9
