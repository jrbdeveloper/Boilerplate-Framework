$.widget("custom.People", {
    options: {
        grid: {
            columns: [
                { name: "FirstName", title: "First Name", data: "FirstName", targets: [0], sortable: true, searchable: true, visible: true, className: "small text-center" },
                { name: "LastName", title: "Last Name", data: "LastName", targets: [1], sortable: true, searchable: true, visible: true, className: "small text-center" },
                { name: "Height", title: "Height", data: "Height.Feet", targets: [2], sortable: true, searchable: true, visible: true, className: "small text-center" },
                { name: "Weight", title: "Weight", data: "Weight", targets: [3], sortable: true, searchable: true, visible: true, className: "small text-center" },
                { name: "EyeColor", title: "Eye Color", data: "EyeColor", targets: [4], sortable: true, searchable: true, visible: true, className: "small text-center" },
                { name: "Hair", title: "Hair Color", data: "Hair.Color", targets: [5], sortable: true, searchable: true, visible: true, className: "small text-center" },
                { name: "Age", title: "Age", data: "Age", targets: [6], sortable: true, searchable: true, visible: true, className: "small text-center" },
            ],
            filters: {
                text: [],
                list: []
            }
        },
    },

    _init: function () {
        var self = this;
        
        self.Grid = $("#grid").empty().Grid({
            pageSize: -1,
            showFilters: true,
            allowSelect: false,
            fixedHeader: true,
            ajax: {
                url: "/api/people/",
                dataSrc: "",
                dataType: 'json'
            },
            columns: self.options.grid.columns
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