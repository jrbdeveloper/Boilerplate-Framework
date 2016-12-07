$.widget("custom.Grid", {
    options: {
        data: {},
        columns:[],
        buttonContainer: "",
        pageSize: 10,
        showFilters: false,
        textFilters: [],
        listFilters: [],
        order: [1, "asc"],
        allowSelect: false,
        fixedHeader: false,
        serverSide: false,
        enableExport: true,
        gridType: ''
    },

    table: {},

    _init: function () { },

    _create: function () {        
        this.Helpers = $.custom.Helpers();
        this._determineImplementation(this.options.gridType);
    },    
    
    _getGridSettings: function () {
        var self = this;
        var settings = {
            dom: (self.options.enableExport) ? 'lfBrtip' : 'lfrtip',
            data: self.options.data.length > 0 ? self.options.data : null,
            ajax: self.options.ajax != null ? self.options.ajax : null,
            serverSide: self.options.serverSide,
            processing: false,
            stateSave: false,
            fixedHeader: self.options.fixedHeader,
            aaSorting: [self.options.order],
            order: [self.options.order],
            deferRender: true,
            scrollY: "50vh",
            scrollX:"100%",
            scrollCollapse: true,
            paging: true,
            lengthChange: true,
            pagingType: "full_numbers",
            iDisplayLength: self.options.pageSize !== '' ? self.options.pageSize : 10,
            buttons: [{
                extend: 'collection',
                text: 'Export',
                autoClose: true,
                buttons: [
                    self._createButton("csv", "CSV"),
                    self._createButton("excel", "Excel"),
                    self._createButton("pdf", "PDF", "landscape"),
                    self._createButton("print", "Print", "landscape")
                ],
            }],

            lengthMenu: [
                [10, 25, 50, 100, -1],
                [10, 25, 50, 100, "All"]
            ],

            columnDefs: (self.options.columns.length > 0)
                ? self.options.columns
                : (self.options.showFilters)
                    ? [{
                        targets: 0,
                        orderable: false,
                        searchable: false,
                        className: 'text-center nopadding',
                        mDataProp: "PID",
                        render: function (data, type, full, meta) {
                            if (self.options.allowSelect) {
                                return '<input name="PID" id="PID" type="checkbox" class="rowCheck" value="' + $(full[1]).html() + '">';
                            } else {
                                return data;
                            }
                        },
                    }]
                    : null,

            initComplete: function (settings, json) {
                var my = this;
                var mySettings = my.api().settings();

                if (self.options.showFilters) {
                    my.api().columns().every(function () {
                        var column = this;
                        var search_string = mySettings[0].aoPreSearchCols[column.index()].sSearch.replace("$", "").replace("^", "");

                        if (column.index() >= 0) {
                            if ($.inArray(column.index(), self.options.textFilters) >= 0) {
                                $('<input class="form-control input input-sm filter" type="text" value="' + search_string + '">')
                                    .appendTo($(column.header()))
                                    .on('keyup', function () {
                                        var val = $.fn.dataTable.util.escapeRegex($(this).val());
                                        column.search(val).draw();
                                    }).on("click", function () {
                                        return false;
                                    });
                            } else if ($.inArray(column.index(), self.options.listFilters) >= 0) {
                                var list = $('<select class="form-control input input-sm filter"><option value=""></option></select>')
                                    .appendTo($(column.header()))
                                    .on('change', function () {
                                        var val = $.fn.dataTable.util.escapeRegex($(this).val());
                                        column.search(val ? '^' + val + '$' : '', true, false).draw();
                                    }).on("click", function () {
                                        return false;
                                    });

                                column.data().unique().sort().each(function (d, j) {
                                    if (Number.isFinite(d)) {
                                        d = d.toFixed(2);
                                    }

                                    if (d && d.indexOf && d.indexOf("href") > 0) {
                                        list.append('<option value="' + $(d).text() + '">' + $(d).text() + '</option>');
                                    } else {
                                        list.append('<option value="' + d + '">' + d + '</option>');
                                    }
                                });
                            }
                        }
                    });
                }

                my.api().columns.adjust().draw();

                self._initializeControls();
                self._registerEvents();
            },
        };

        return settings;
    },
    
    _registerEvents: function () {
        var self = this;

        $(self.options.selector).on({
            "order.dt": function () {
                self._resetChecks();
            }
        });

        self.AllChecks.on({
            click: function () {
                $(this).closest("tr").toggleClass("selected");
            }
        });

        self.CheckAll.on({
            click: function () {
                self._toggleSelected();
            }
        });

        self.ResetFiltersBtn.on({
            click: function () {
                self._reset();
            }
        });

        self.PageLength.on({
            change: function () {
                self._resetChecks();
            }
        });
    },
    
    _initializeControls: function () {
        this.CheckAll = $(".checkall");
        this.AllChecks = $(".rowCheck");        
        this.Wrapper = $("#" + this.element[0].id + "_wrapper .dataTables_filter");
        this.PageLength = $("select[name=" + this.element[0].id + "_length]")
        this.ResetFiltersBtn = $('<a/>', { id: "resetFilters", text: "Reset Filters" }).addClass("dt-button buttons-html5");
        this.Filters = $('.filter');
    },
    
    _injectButtons: function () {
        var self = this;

        if (!this.table.buttons().container().find($(this.ResetFiltersBtn)).length > 0) {
            self.table.buttons().container().append(self.ResetFiltersBtn);
        }
        
        self.table.buttons().container().addClass("pull-right");
    },
    
    _reset: function () {
        var tableContainer = this.Helpers.CreateElement("table", this.element[0].id, "display nowrap table table-striped table-bordered");
        var btnContainer = this.Helpers.CreateElement("div", "export-buttons", "");

        $("#table_container").empty().append(tableContainer);

        this.table = this._createTable(tableContainer);
        this._initializeControls();
        this._registerEvents();
        this._injectButtons();
    },

    _createTable: function (container) {
        var table = $(container).DataTable(this._getGridSettings());
        return table;
    },
    
    _createButton: function (type, text, layout) {
        var self = this;

        var obj = {
            extend: type,
            text: text,
            orientation: layout,
            columns: ':all',
            exportOptions: {
                rows: '.selected',
                modifier: {
                    selected: true
                },
                format: {
                    header: function (data, columnIdx) {
                        return data.substring(0, data.indexOf("<"));
                    }
                }
            },

            SelectorOpts: { filter: 'applied', order: 'current' }
        };

        return obj;
    },

    _resetChecks: function () {
        var self = this;

        self.AllChecks = $(".rowCheck");

        if ($(self.CheckAll).prop('checked')) {
            $(self.CheckAll).prop('checked', false);
            $(self.CheckAll).prop('checked', true);
        }

        self._toggleSelected();
    },
   
    _toggleSelected: function () {
        var self = this;
        var chk = $(self.CheckAll).prop('checked');

        self.AllChecks.each(function () {
            $(this).prop('checked', chk);
            if (self.AllChecks.prop('checked')) {
                $(this).closest("tr").addClass("selected");
            } else {
                $(this).closest("tr").removeClass("selected");
            }            
        });
    },
    
    _determineImplementation: function (gridType) {
        if (gridType == "simple") {
            this._createTable("#" + this.element[0].id);
        } else {
            this._reset();
        }
    },
    
    _showLog: function (msg) {
        if (this.options.showlogs) {
            console.log(msg);
        }
    },
});