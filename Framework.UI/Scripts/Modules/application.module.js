$.widget("custom.Application", {
    options: {
        Configuration: {},
        showlogs: false
    },

    _init: function () {
        this.WriteLog("Application Initialized");
        this._registerEvents();
    },

    _create: function () {
        this.Configuration = this.GetConfiguration();
        this.Tracker = $.custom.Tracker({ showlogs: this.options.showlogs });
        this.Helpers = $.custom.Helpers();
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
    
    Grid: function (myOptions) {
        var grid = new $.custom.Grid();
        grid.options = myOptions;

        return grid;
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

    GetConfiguration: function () {
        this.options.Configuration = this._get({}, "/Configuration/Get/", false);
        return this.options.Configuration;
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

    SubmitWithReason: function (ctrl, form, submitTo) {
        var self = this;

        // Get the list of reasons from the database
        var reasons = self.GetModel("", "/TransferReason/GetAll", false);

        //Create a select list control and insert the reason options
        var selectList = $("<select name='TransferReasonID' id='TransferReasonID'></select>").append(document.createElement("option"));

        $.each(reasons, function (i, data) {
            var option = document.createElement("option");
            option.text = data.Reason;
            option.value = data.TransferReasonID;
            $(option).appendTo(selectList);
        });

        var div = $("<div />").append("Please select a reason for this action.").append(selectList);

        //show the modal
        self.Helpers.ShowError("Choose a reaon", div, function () {

            // Inject the select list into the form on the page to be submitted
            selectList.prependTo(form).hide();

            //Submit the form
            self.Submit(ctrl, form, submitTo);
        });
    },
    
    _get: function (data, api, async) {
        var self = this;
        var ret;
        
        $.ajax({
            method: "GET",
            url: api,
            dataType: "json",
            data: data,
            async: async,
        }).done(function (result) {
            ret = result;
        }).fail(function (text, msg) {
        });
        
        return ret;
    },

    _registerEvents: function () {
        var self = this;

        $("#nav_back").on({
            click: function () {
                self.Helpers.ShowProcessing();

                if (window.history.back() != undefined) {    
                    window.history.back();
                } else {
                    self.Helpers.HideProcessing();
                }
            }
        });

        $("#nav_forward").on({
            click: function () {
                self.Helpers.ShowProcessing();

                if (window.history.forward() != undefined) {
                    window.history.forward();
                } else {
                    self.Helpers.HideProcessing();
                }
            }
        });
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