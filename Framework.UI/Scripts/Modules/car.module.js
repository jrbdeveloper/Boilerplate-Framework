$.widget("custom.Car", {
    options: {
    },

    _init: function () {
        var self = this;

        self.Grid = $("#grid").empty().Grid({
            showFilters: true,
            allowSelect: true,
            fixedHeader: true,
            ajax: {
                url: "/api/car/",
                dataSrc: ""
            },
            textFilters: [],
            listFilters: [1, 2, 3],
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
                { name: "Seat", title: "Seat", data: "Seat", targets: [1], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "SteeringWheel", title: "Steering Wheel", data: "SteeringWheel", targets: [2], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "Engine", title: "Engine", data: "Engine", targets: [3], sortable: true, searchable: true, visible: true, className: "small" },
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