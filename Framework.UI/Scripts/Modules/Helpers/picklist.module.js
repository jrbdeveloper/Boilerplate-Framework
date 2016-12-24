$.widget("custom.PickList", {
    options: {
        selected: []
    },

    _init: function () {
    },

    _create: function () {
        this.Application = Singleton.getInstance();
        this._initializeControls();
        this._registerEvents();
    },

    _registerEvents: function () {
        var self = this;

        self.SaveBtn.on({
            click: function () {
                $("#ActiveItems option").prop("selected", "true");
            }
        });

        self.IncludeBtn.on({
            click: function () {
                self._include($("#InactiveItems option:selected"), $("#ActiveItems option"), self.ActiveList);
            }
        });

        self.ExcludeBtn.on({
            click: function () {
                self._exclude($("#ActiveItems option:selected"), $("#InactiveItems option"), self.InactiveList);
            }
        });
    },

    _createOption: function (ctrl) {
        var option = document.createElement("option");
        option.text = ctrl.text;
        option.value = ctrl.value;

        return option;
    },

    _getValues: function (ctrl) {
        var valuesArray = ctrl.map(function () {
            return this.value;
        }).get();

        return valuesArray;
    },

    _include: function (selectedItems, savedItems, destination) {
        var self = this;

        $.each(selectedItems, function (index, item) {
            var option = self._createOption(item);

            if ($.inArray($(item).val(), self._getValues(savedItems)) == -1) {
                $(option).appendTo(destination);
                $(item).remove();
            }
        });
    },

    _exclude: function (selectedItems, savedItems, destination) {
        var self = this;

        $.each(selectedItems, function (index, item) {
            var option = self._createOption(item);

            if ($.inArray($(item).val(), self._getValues(savedItems)) == -1) {
                $(option).prependTo(destination);
                $(item).remove();
            }
        });
    },

    _initializeControls: function () {
        this.SaveBtn = $("#saveBtn");

        this.IncludeBtn = $("#include-button");
        this.ExcludeBtn = $("#exclude-button");

        this.InactiveList = $("#InactiveItems");
        this.ActiveList = $("#ActiveItems");
    },
});