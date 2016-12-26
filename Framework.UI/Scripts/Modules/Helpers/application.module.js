$.widget("custom.Application", {
    options: {
        showlogs: false
    },

    _init: function () {
        this.WriteLog("Application Initialized");
        this._registerEvents();
    },

    _create: function () {
        this.Tracker = $.custom.Tracker({ showlogs: this.options.showlogs });
        this.Helpers = $.custom.Helpers({ showlogs: this.options.showlogs });
    },

    Cancel: function () {
        var self = this;

        self.Helpers.Confirm("Please Confirm", "Are you sure you would like to cancel?", function () {
            document.location.reload();
        });
    },
    
    Submit: function (ctrl, frm, action) {
        var self = this;

        self.Helpers.Confirm("Please Confirm", "Are you sure you want to " + $(ctrl).val() + "?", function () {
            self.Helpers.ShowProcessing();
            frm.prop("action", action);
            frm.submit();
        });
    },
       
    GetModel: function (id, api, async) {
        var model = this._get({ id: id }, api, async);

        return model;
    },
    
    DeleteModel: function (id, api) {
        return this._get({ id: id }, api, false);
    },

    BindDataToModel: function (model, data) {
        var self = this;

        $.each(data, function (key, value) {
            if (model[key]) {
                self.WriteLog(model[key]);
                if ($(model[key]).value !== undefined) {
                    $(model[key]).val(value);
                } else {
                    $(model[key]).html(value);
                }
            }
        });
    },
    
    CreateIncrementer: function (ctrl) {
        var self = this;
        var incrementer = $(ctrl).TouchSpin({
            verticalbuttons: true,
            step: 0.01,
            decimals: 2,
            boostat: 5,
            maxboostedstep: 10,
            mousewheel: true,
            buttondown_class: "btn btn-default",
            buttonup_class: "btn btn-default",
            min: self.Configuration.MinimumGPA,
            max: self.Configuration.MaximumGPA,
        });

        return incrementer;
    },    
    
    _get: function (data, api, async) {
        var self = this;
        var ret;

        $.ajax({
            method: "GET",
            url: api,
            dataType: "json",
            data: data.id != null ? data : "",
            async: async,
        }).done(function (result) {
            ret = result;
        }).fail(function (text, msg) {
        });
        
        return ret;
    },

    _registerEvents: function () {
        var self = this;        
    },
    
    WriteLog: function (msg) {
        if (this.options.showlogs) {
            console.log(msg);
        }
    },
});

var Singleton = (function () {
    var instance;

    function createInstance() {
        var object = $.custom.Application({ showlogs: true });
        return object;
    }

    return {
        getInstance: function () {
            if (!instance) {
                instance = createInstance();
            }
            return instance;
        }
    };
})();