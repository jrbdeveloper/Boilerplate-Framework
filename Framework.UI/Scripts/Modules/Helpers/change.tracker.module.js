$.widget("custom.Tracker", {
    options: { },

    _init: function () {
        this._writeLog("Tracker: Initialized");
    },

    _create: function () {
        this.Tracker = new Object;
        this._registerEvents();
        this._setFieldsUnchanged();        
    },

    HasChanges: function (e) {
        var self = this;
        var hasChanges = false;

        self._writeLog("Tracker: Checking for changes", self.Tracker);
        self._writeLog("TRACKED CONTROLS: " + JSON.stringify(self.Tracker));

        $.each(self.Tracker, function (item) {
            if (self.Tracker.hasOwnProperty(item)) {
                if (self.Tracker[item]) {
                    hasChanges = true;
                }
            }
        });

        return hasChanges;
    },

    Reset: function () {
        this._writeLog("Tracker: Reseting");
        this.Tracker = new Object;
        this._setFieldsUnchanged();
    },

    _registerEvents: function () {
        var self = this;

        self._writeLog("Tracker: Registering events");
        
        $(".track").on({
            change: function () {
                self._writeLog("Tracker: A field changed", self.Tracker);
                self.Tracker[$(this).attr('id')] = true;
            }
        });
    },

    _setFieldsUnchanged: function () {
        var self = this;

        self._writeLog("Tracker: Set Fields Unchanged", self.Tracker);

        $('.track').each(function (item) {
            self.Tracker[$(item).attr('id')] = false;
        });
    },

    _writeLog: function (msg) {
        if (this.options.showlogs) {
            console.log(msg);
        }
    },
});