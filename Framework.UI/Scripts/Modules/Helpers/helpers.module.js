$.widget("custom.Helpers", {
    options: {},

    _init: function () {
        this._writeLog("Helpers Initialized");
    },

    _create: function () {
        this._initializeControls();
    },

    Sum: function (params) {
        var result = 0;

        for (i = 0; i < params.length; i++) {
            if (parseInt(params[i]) >= 0) {
                result += parseInt(params[i]);
            }
        }

        return result;
    },

    ShowError: function (title, message, callback) {
        this.alertModalTitle.html(title);
        this.alertModalBody.html(message);

        if (callback != undefined) {
            this.alertModal.modal({ backdrop: "static", keyboard: false }).one("click", "#modalOkBtn", callback);
        } else {
            this.alertModal.modal();
        }        
    },

    Confirm: function (title, message, callback) {
        this.confirmModalTitle.html(title);
        this.confirmModalBody.html(message);

        this.confirmModal.modal({ backdrop: "static", keyboard: false }).one("click", "#confirmOk", callback);
    },

    ShowProcessing: function () {
        var count = 0;
        var interval;

        this.ProcessingModal.modal({
            show: true,
            backdrop: 'static',
            keyboard: false
        });

        this.ProcessingModal.on("shown.bs.modal", function () {
            interval = setInterval(function () {
                this.ProgressBar.css('width', (count += 3) + '%').attr('aria-valuenow', (count += 3));
            }, 100);
        });

        this.ProcessingModal.on("hidden.bs.modal", function () {
            clearInterval(interval);
            this.ProgressBar.css('width', 0 + '%').attr('aria-valuenow', 0);
        });
    },

    HideProcessing: function () {
        this.ProcessingModal.modal("hide");
    },

    ClearFields: function () {
        this.formFields.val('');
    },

    ScrollTop: function () {
        $("html, body").animate({ scrollTop: 0 }, "fast");
    },

    FormatDate: function (unformatted) {
        var formatted;

        if (unformatted != null) {
            formatted = new Date(parseInt(unformatted.substr(6))).toUTCString();
        }

        return formatted;
    },

    DefaultGridColumns: function (cols) {
        var columns = [
                {
                    name: "Selector",
                    title: "<input type='checkbox' class='checkall' />",
                    data: "CPID",
                    targets: 0,
                    orderable: false,
                    searchable: false, 
                    visible: false,
                    className: 'text-center nopadding',
                    render: function (data, type, full, meta) {
                        return '<input name="PID" id="PID" type="checkbox" class="rowCheck" value="' + data.trim() + '">';
                    }
                },
                {
                    name: "CPID",
                    title: "CPID",
                    data: "CPID",
                    targets: 0,
                    orderable: true,
                    searchable: true,
                    visible: false,
                    className: "small text-center",
                    render: function (data, type, full, meta) {
                        return "<a href='/Student/Details/" + data + "'>" + data + "</a>";
                    }
                },
                { name: "Category", title: "Category", data: "CategoryName", targets: 0, orderable: true, searchable: true, visible: false, className: "small" },
                { name: "Query", title: "Query", data: "QueryName", targets: 3, orderable: true, searchable: true, visible: false, className: "small" },
                {
                    name: "GPA",
                    title: "GPA",
                    data: "GPA",
                    targets: 0,
                    orderable: true,
                    searchable: true,
                    visible: false,
                    className: "small text-right",
                    render: function (data, type, full, meta) {
                        return data.toFixed(2);
                    }
                },
                {
                    name: "Units",
                    title: "Units",
                    data: "UNITS",
                    targets: 0,
                    orderable: true,
                    searchable: true,
                    visible: false,
                    className: "small text-right",
                    render: function (data, type, full, meta) {
                        return data.toFixed(2);
                    }
                },
                {
                    name: "AP Units",
                    title: "AP Units",
                    data: "ap_units",
                    targets: 0,
                    orderable: true,
                    searchable: true,
                    visible: false,
                    className: "small text-right",
                    render: function (data, type, full, meta) {
                        return data.toFixed(3);
                    }
                },
                { name: "Reviewed", title: "Reviewed", data: "Reviewed", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "Admission Code", title: "Admission Code", data: "admissioncode", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "TCE", title: "TCE", data: "TCE", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "TCM", title: "TCM", data: "TCM", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "TCO", title: "TCO", data: "TCO", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "AU", title: "AU", data: "AU", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "Visa", title: "Visa", data: "visa_code", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "Home Loc", title: "Home Loc", data: "holoco", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "Last School", title: "Last School", data: "ulstyp", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "Ulink", title: "Ulink", data: "uspecl", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "Major", title: "Major", data: "major_code", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },
                { name: "Reviewer", title: "Reviewer", data: "reviewer", targets: 0, orderable: true, searchable: true, visible: false, className: "small text-center" },

                { name: "AES TERM CODE", title: "AES TERM CODE", data: "AES_TERM_CODE", targets: 0, visible: false },
                { name: "AMP CRS CNT", title: "AMP CRS CNT", data: "AMP_CRS_CNT", targets: 0, visible: false },
                { name: "APCT DECN", title: "APCT DECN", data: "APCT_DECN", targets: 0, visible: false },
                { name: "APCT TYPE", title: "APCT TYPE", data: "APCT_TYPE", targets: 0, visible: false },
                { name: "APLN DECN", title: "APLN DECN", data: "APLN_DECN", targets: 0, visible: false },
                { name: "APLN DECN DT", title: "APLN DECN DT", data: "APLN_DECN_DT", targets: 0, visible: false },
                { name: "APLN REF NO", title: "APLN REF NO", data: "APLN_REF_NO", targets: 0, visible: false },
                { name: "AltMajPrepRvStat", title: "AltMajPrepRvStat", data: "AltMajPrepRvStat", targets: 0, visible: false },
                { name: "AltMajPrep_GPA", title: "AltMajPrep_GPA", data: "AltMajPrep_GPA", targets: 0, visible: false },
                { name: "AltMajor", title: "AltMajor", data: "AltMajor", targets: 0, visible: false },
                { name: "Alt mj DeptCode", title: "Alt mj DeptCode", data: "Alt_mj_DeptCode", targets: 0, visible: false },
                { name: "AppDecisionDateString", title: "AppDecisionDateString", data: "AppDecisionDateString", targets: 0, visible: false },
                { name: "CAMPUS", title: "CAMPUS", data: "CAMPUS", targets: 0, visible: false },
                { name: "Coursework", title: "Coursework", data: "Coursework", targets: 0, visible: false },
                { name: "CreatedBy", title: "CreatedBy", data: "CreatedBy", targets: 0, visible: false },
                { name: "DateAddedString", title: "DateAddedString", data: "DateAddedString", targets: 0, visible: false },
                { name: "DateCreated", title: "DateCreated", data: "DateCreated", targets: 0, visible: false },
                { name: "DateUpdated", title: "DateUpdated", data: "DateUpdated", targets: 0, visible: false },
                { name: "MP_CRS_CNT", title: "MP_CRS_CNT", data: "MP_CRS_CNT", targets: 0, visible: false },
                { name: "MajPrepRvwStat", title: "MajPrepRvwStat", data: "MajPrepRvwStat", targets: 0, visible: false },
                { name: "PID9", title: "PID9", data: "PID9", targets: 0, visible: false },
                { name: "Reason", title: "Reason", data: "Reason", targets: 0, visible: false },
                { name: "Reason_desc", title: "Reason_desc", data: "Reason_desc", targets: 0, visible: false },
                { name: "ReviewDateString", title: "ReviewDateString", data: "ReviewDateString", targets: 0, visible: false },
                { name: "Summary", title: "Summary", data: "Summary", targets: 0, visible: false },
                { name: "Term", title: "Term", data: "Term", targets: 0, visible: false },
                { name: "UpdateBy", title: "UpdateBy", data: "UpdateBy", targets: 0, visible: false },
                { name: "YEAR", title: "YEAR", data: "YEAR", targets: 0, visible: false },
                { name: "adjusted_units", title: "adjusted_units", data: "adjusted_units", targets: 0, visible: false },
                { name: "admissioncode_isnul", title: "admissioncode_isnul", data: "admissioncode_isnul", targets: 0, visible: false },
                { name: "ap cpid", title: "ap cpid", data: "ap_cpid", targets: 0, visible: false },
                { name: "apln_decn", title: "apln_decn", data: "apln_decn", targets: 0, visible: false },
                { name: "c apln decn", title: "c apln decn", data: "c_apln_decn", targets: 0, visible: false },
                { name: "coll code", title: "coll code", data: "coll_code", targets: 0, visible: false },
                { name: "dateadded", title: "dateadded", data: "dateadded", targets: 0, visible: false },
                { name: "dept code", title: "dept code", data: "dept_code", targets: 0, visible: false },
                { name: "majorprepgpa", title: "majorprepgpa", data: "majorprepgpa", targets: 0, visible: false },
                { name: "reviewdate", title: "reviewdate", data: "reviewdate", targets: 0, visible: false },
                { name: "reviewerid", title: "reviewerid", data: "reviewerid", targets: 0, visible: false },
                { name: "student name", title: "student name", data: "student_name", targets: 0, visible: false },
                { name: "tag submitted", title: "tag submitted", data: "tag_submitted", targets: 0, visible: false },
                { name: "uadres", title: "uadres", data: "uadres", targets: 0, visible: false },
                { name: "uigetc", title: "uigetc", data: "uigetc", targets: 0, visible: false },
                { name: "ulstsc", title: "ulstsc", data: "ulstsc", targets: 0, visible: false },
                { name: "uspecg", title: "uspecg", data: "uspecg", targets: 0, visible: false },
                { name: "uspect", title: "uspect", data: "uspect", targets: 0, visible: false },
                { name: "utrapc", title: "utrapc", data: "utrapc", targets: 0, visible: false },
                { name: "utrape", title: "utrape", data: "utrape", targets: 0, visible: false },
                { name: "utrapi", title: "utrapi", data: "utrapi", targets: 0, visible: false },
        ];

        if (cols != undefined && cols.length > 0) {
            columns = columns.concat(cols);
        }

        for (var x = 0; x < columns.length; x++) {
            columns[x].targets = x;
        }

        return columns;
    },

    GetColumnByName: function (name) {
        var returnVal = "";
        var columns = this.DefaultGridColumns();

        $.each(columns, function (i, item) {
            if ($.trim(item.name) === $.trim(name)) {
                returnVal = item;
                return false;
            }
        });

        return returnVal;
    },

    GetColumnSubset: function (cols) { 
        var self = this;
        var myCols = [];
        
        $.each(self.DefaultGridColumns(), function (i, item) {
            if ($.inArray($.trim(item.name), cols) >= 0) {
                item.targets = i;
                item.visible = true;
            }

            myCols.push(item);
        });

        return myCols;
    },
    
    CreateElement: function (type, name, cssClass) {
        var element = document.createElement(type);
        element.id = name;
        $(element).addClass(cssClass);

        return element;
    },

    _initializeControls: function () {
        this.alertModal = $("#alertModal");
        this.alertModalTitle = $("#alertModal .modal-title");
        this.alertModalBody = $("#alertModal .modal-body");

        this.confirmModal = $("#confirmModal");
        this.confirmModalTitle = $("#confirmModal .modal-title");
        this.confirmModalBody = $("#confirmModal .modal-body");

        this.ProcessingModal = $("#ProcessingModal");
        this.ProgressBar = $('.progress-bar');

        this.formFields = $(".form-control");
    },

    _writeLog: function (msg) {
        if (this.options.showlogs) {
            console.log(msg);
        }
    },
});