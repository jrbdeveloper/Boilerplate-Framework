$.widget("custom.Car", {
    options: {
    },

    _init: function () {
        var self = this;

        $("#PickList").PickList({
            Ajax: {
                url: "/api/car",
                data: ""
            },
            ActiveLabel: "Active",
            InactiveLabel: "Inactive"
        });

        self.Grid = $("#grid").empty().Grid({
            showFilters: true,
            allowSelect: true,
            fixedHeader: true,
            ajax: {
                url: "/api/car/getcars/",
                dataSrc: ""
            },
            textFilters: [],
            listFilters: [1, 2, 3, 4],
            columns: [
                {
                    name: "Selector",
                    title: "<input type='checkbox' class='checkall' />",
                    data: "ID",
                    className: "text-center",
                    targets: 0,
                    orderable: false,
                    searchable: false,
                    visible: true,
                    render: function (data, type, full, meta) {
                        return '<input name="ID" id="ID" type="checkbox" class="rowCheck" value="' + data + '">';
                    }
                },
                { name: "Make", title: "Make", data: "Make", targets: [1], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "Model", title: "Model", data: "Model", targets: [2], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "Year", title: "Year", data: "Year", targets: [3], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "Color", title: "Color", data: "Color", targets: [4], sortable: true, searchable: true, visible: true, className: "small" }
            ]
        });
    },

    _create: function () {
        this.Application = Singleton.getInstance();
        this._initializeControls();
        this._registerEvents();
    },

    _registerEvents: function () {
        var self = this;
    },

    _initializeControls: function () {
        
    },
});