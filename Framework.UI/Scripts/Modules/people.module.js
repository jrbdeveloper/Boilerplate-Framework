$.widget("custom.People", {
    options: {
    },

    _init: function () {
        var self = this;
        
        self.Grid = $("#grid").empty().Grid({
            showFilters: true,
            allowSelect: true,
            fixedHeader: true,
            ajax: {
                url: "/api/people/",
                dataSrc: "",
                dataType: 'json'
            },
            textFilters: [],
            listFilters: [1, 2, 3, 4, 5, 6, 7],
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
                { name: "FirstName", title: "First Name", data: "FirstName", targets: [1], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "LastName", title: "Last Name", data: "LastName", targets: [2], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "Height", title: "Height", data: "Height.Feet", targets: [3], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "Weight", title: "Weight", data: "Weight", targets: [4], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "EyeColor", title: "Eye Color", data: "EyeColor", targets: [5], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "Hair", title: "Hair Color", data: "Hair.Color", targets: [6], sortable: true, searchable: true, visible: true, className: "small" },
                { name: "Age", title: "Age", data: "Age", targets: [7], sortable: true, searchable: true, visible: true, className: "small" },
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