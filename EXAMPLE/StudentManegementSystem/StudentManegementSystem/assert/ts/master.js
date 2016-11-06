var Master;
(function (Master) {
    $(function () {
        student.init();
        $('#menu-student').on('click', function () {
            student.init();
        });
        $('#menu-subject').on('click', function () {
            subject.init();
        });
        $('#btnModelAction').on('click', function (e) {
            var ac = Number($(e.target).attr('data-bind'));
            if (ac == Number(modelAction.StudentCreate)) {
                student.create();
            }
            else if (ac == Number(modelAction.StudentUpdate)) {
                student.update();
            }
            else if (ac == Number(modelAction.StudentSubjectRegister)) {
                student.saveStudentSubject();
            }
            else if (modelAction.SubjectCreate) {
                subject.create();
            }
            else if (modelAction.SubjectUpdate) {
                subject.update();
            }
        });
    });
    /////////////////////////
    //////////// STUDENT
    /////////////////////////
    var student = {
        init: function (e) {
            student.renderControllers();
            student.read();
        },
        initControls: function (e) {
            $('#btnAddStudent').on('click', function () {
                var studentViewViewModel = {
                    studentName: '',
                    studentEmail: '',
                    phoneNumber: '',
                    address: '',
                    school: '',
                    title: 'Student Create',
                    mode: Number(modelAction.StudentCreate),
                    studentId: '0',
                    dob: new Date(),
                    studentImage: 'no.jpg'
                };
                student.renderModelTemplate(studentViewViewModel);
            });
            $('#gv-student').kendoGrid({
                columns: [
                    {
                        field: "StudentId",
                        hidden: true
                    },
                    {
                        field: "Image",
                        width: 120,
                        title: "Image",
                        template: "<img src='/assert/images/#: Image#' alt='' class='img- thumbnail' width='75px' height=75px>",
                        filterable: false
                    },
                    {
                        field: "Name",
                        title: "Name"
                    },
                    {
                        field: "Email",
                        title: "Email",
                    },
                    {
                        title: 'Actions',
                        width: 400,
                        command: [
                            {
                                name: "details",
                                click: function (e) {
                                    var tr = $(e.target).closest("tr");
                                    var d;
                                    d = $('#gv-student').data('kendoGrid').dataItem(tr);
                                    student.readSingle(d.StudentId);
                                }
                            }, {
                                name: "subjects",
                                click: function (e) {
                                    var tr = $(e.target).closest("tr");
                                    var d;
                                    d = $('#gv-student').data('kendoGrid').dataItem(tr);
                                    student.renderStudentSubjectTemplate(d.StudentId);
                                }
                            },
                            {
                                name: "remove",
                                click: function (e) {
                                    var tr = $(e.target).closest("tr");
                                    var d;
                                    d = $('#gv-student').data('kendoGrid').dataItem(tr);
                                    student.delete(d.StudentId);
                                }
                            }
                        ]
                    }
                ],
                pageable: true,
                filterable: true
            });
        },
        read: function (e) {
            new apiConnector().callservice('/api/Student/StudentRead', null, webMethod.Get).done(function (e) {
                console.log(e);
                $('#gv-student').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: e.Content, pageSize: 10 }));
            });
        },
        readSingle: function (e) {
            new apiConnector().callservice('/api/Student/StudentReadSingle?id=' + e, null, webMethod.Get).done(function (e) {
                console.log(e);
                if (e.Success) {
                    var studentViewViewModel = {
                        studentName: e.Content.Student.Name,
                        studentEmail: e.Content.Student.Email,
                        phoneNumber: e.Content.StudentMore.PhoneNumber,
                        address: e.Content.StudentMore.Address,
                        school: e.Content.StudentMore.School,
                        title: 'Student Update',
                        mode: Number(modelAction.StudentUpdate),
                        studentId: e.Content.Student.StudentId,
                        dob: e.Content.Student.Dob,
                        studentImage: e.Content.Student.Image
                    };
                    student.renderModelTemplate(studentViewViewModel);
                }
                else {
                    swal("something went wrong", '', 'error');
                }
            });
        },
        update: function (e) {
            var data = {
                Student: {
                    StudentId: $('#hndStudentId').val(),
                    Name: $('#txtStuedntName').val(),
                    Dob: $('#txtBirthDay').data('kendoDatePicker').value(),
                    Email: $('#txtEmail').val(),
                    Image: $('#hndImage').val()
                },
                StudentMore: {
                    PhoneNumber: $('#txtPhoneNumber').val(),
                    Address: $('#txtAddress').val(),
                    School: $('#txtSchool').val(),
                    StudentId: $('#hndStudentId').val()
                }
            };
            console.log(data);
            new apiConnector().callservice('/api/Student/StudentUpdate', data, webMethod.Post).done(function (e) {
                console.log(e);
                if (e.Success) {
                    swal("Success !", "Student Update is success", "success");
                    $('#model-action').modal('hide');
                    student.read();
                }
                else {
                    sweetAlert("Oops...", "Something went wrong!", "error");
                }
            });
        },
        delete: function (e) {
            swal({
                title: "Are you sure?",
                text: "Do you want to Delete this recode ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                var data = {
                    StudentId: e
                };
                new apiConnector().callservice('/api/Student/StudentDelete', data, webMethod.Post).done(function (e) {
                    console.log(e);
                    if (e.Success) {
                        swal("Success !", "Student Delete is success", "success");
                        student.read();
                    }
                    else {
                        sweetAlert("Oops...", "Something went wrong!", "error");
                    }
                });
            });
        },
        create: function (e) {
            var data = {
                Student: {
                    StudentId: 0,
                    Name: $('#txtStuedntName').val(),
                    Dob: $('#txtBirthDay').data('kendoDatePicker').value(),
                    Email: $('#txtEmail').val(),
                    Image: $('#hndImage').val()
                },
                StudentMore: {
                    PhoneNumber: $('#txtPhoneNumber').val(),
                    Address: $('#txtAddress').val(),
                    School: $('#txtSchool').val(),
                    StudentId: 0
                }
            };
            console.log(data);
            new apiConnector().callservice('/api/Student/StudentCreate', data, webMethod.Post).done(function (e) {
                console.log(e);
                if (e.Success) {
                    //TsMessage.ShowSuccess("Student create is success");
                    $('#model-action').modal('hide');
                    student.read();
                }
            });
        },
        renderControllers: function (e) {
            var template = kendo.template($("#template-student").html());
            $('#main-placeHolder').html(template({}));
            student.initControls();
        },
        renderModelTemplate: function (e) {
            var template = kendo.template($("#template-student-update").html());
            $('#model-content').html(template(e));
            $('#model-action').modal('show');
            $('#txtBirthDay').kendoDatePicker({ value: e.dob });
            $('#lblModelMessage').text(e.title);
            $('#btnModelAction').attr('data-bind', e.mode);
            $("#files-student-image").kendoUpload({
                async: {
                    saveUrl: "/api/Student/SaveImage",
                    removeUrl: "remove",
                    autoUpload: true,
                },
                complete: function (e) {
                    console.log(e);
                }
            });
        },
        renderStudentSubjectTemplate: function (e) {
            var template = kendo.template($("#template-student-subject-Studentview").html());
            $('#model-content').html(template({}));
            $('#lblModelMessage').text('Register subjects to student');
            $('#btnModelAction').attr('data-bind', Number(modelAction.StudentSubjectRegister));
            $('#hndStudentId2').val(e);
            $('#gv-student-subject-Studentview').kendoGrid({
                columns: [
                    {
                        field: "SubjectId",
                        hidden: true
                    },
                    {
                        field: "Name",
                        width: 120,
                        title: "Subject Name"
                    },
                    {
                        field: "RegDate",
                        title: "Reg Date"
                    },
                    {
                        field: "Fee",
                        title: "Fee"
                    },
                    {
                        width: 400,
                        command: [
                            {
                                name: "destroy",
                                click: function (e) {
                                    var tr = $(e.target).closest("tr");
                                    var d;
                                    d = $('#gv-student').data('kendoGrid').dataItem(tr);
                                    alert(d.SubjectId);
                                }
                            }
                        ]
                    }
                ],
                pageable: true,
                noRecords: '<h3>No subject registed.</h3>'
            });
            $('#ddSubject').kendoComboBox({
                dataValueField: 'value',
                dataTextField: 'text'
            });
            $('#btnAddSubjectToStudent').on('click', function () {
                var arr = JSON.parse($('#studentSubjectList').val());
                var subjectId = $('#ddSubject').data('kendoComboBox').value();
                var text = $('#ddSubject').data('kendoComboBox').text();
                var fee = $.trim(text.split('$')[1]);
                var subjectName = $.trim(text.split('-')[0]);
                if ($.grep(arr, function (e) {
                    var an;
                    an = e;
                    return an.SubjectId == subjectId;
                }).length != 0) {
                    sweetAlert('student cannot duplicate subjects', '', 'error');
                    return;
                }
                arr.push({ SubjectId: subjectId, Name: subjectName, RegDate: new Date(), Fee: fee });
                $('#studentSubjectList').val(JSON.stringify(arr));
                $('#gv-student-subject-Studentview').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: arr, pageSize: 5 }));
            });
            $('#model-action').modal('show');
            new apiConnector().callservice('/api/Student/StudentSubjectList?studentId=' + e, null, webMethod.Get).done(function (e) {
                console.log(e);
                if (e.Success) {
                    $('#studentSubjectList').val(JSON.stringify(e.Content));
                    $('#gv-student-subject-Studentview').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: e.Content, pageSize: 5 }));
                    student.readSubjectList();
                }
                else {
                    sweetAlert('something went wrong', '', 'error');
                }
            });
        },
        readSubjectList: function () {
            new apiConnector().callservice('/api/Subject/SubjectRead', null, webMethod.Get).done(function (e) {
                if (e.Success) {
                    var arr = [];
                    $.each(e.Content, function (i, d) {
                        arr.push({ text: d.Name + ' - $' + d.Fee, value: d.SubjectId });
                    });
                    $('#ddSubject').data('kendoComboBox').setDataSource(new kendo.data.DataSource({ data: arr }));
                }
                else {
                    sweetAlert('something went wrong', 'cannot read subject list', 'error');
                }
            });
        },
        saveStudentSubject: function (e) {
            swal({
                title: "Are you sure?",
                text: "Do you want to Save this recodes ?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes",
                closeOnConfirm: false
            }, function () {
                var arr = JSON.parse($('#studentSubjectList').val());
                var subjects = [];
                $.each(arr, function (i, d) {
                    subjects.push(Number(d.SubjectId));
                });
                new apiConnector().callservice('/api/Student/AddStudentSubject', { studentId: Number($('#hndStudentId2').val()), subjectId: subjects }, webMethod.Post).done(function (e) {
                    if (e.Success) {
                        sweetAlert('Success', 'Success', 'success');
                    }
                    else {
                        sweetAlert('something went wrong', 'cannot read subject list', 'error');
                    }
                });
            });
        },
    };
    /////////////////////////
    //////////// SUBJECT
    /////////////////////////
    var subject = {
        init: function (e) {
            subject.renderControllers();
            subject.read();
        },
        initControls: function (e) {
            $('#btnAddSubject').on('click', function () {
                var subjectViewViewModel = {
                    subjectName: '',
                    fee: 0.00,
                    subjectId: 0
                };
                subject.renderModelTemplate(subjectViewViewModel);
                //subject.renderTagGrid(e.Content.subjectModuleList);
            });
            $('#gv-subject').kendoGrid({
                columns: [
                    {
                        field: "SubjectId",
                        title: "Subject Id",
                        width: 75
                    },
                    {
                        field: "Name",
                        title: "Subject Name"
                    },
                    {
                        field: "Fee",
                        title: "Subject Fee"
                    },
                    {
                        command: [
                            {
                                name: "details",
                                click: function (e) {
                                    console.log(e);
                                    var tr = $(e.target).closest("tr");
                                    var d;
                                    d = $('#gv-subject').data('kendoGrid').dataItem(tr);
                                    subject.readSingle(d.SubjectId);
                                }
                            },
                            {
                                name: "destroy",
                                click: function (e) {
                                }
                            }
                        ]
                    },
                ],
                noRecords: "<h3> no recodes avaiable.</h3>",
                filterable: true,
            });
        },
        read: function (e) {
            new apiConnector().callservice('/api/Subject/SubjectRead', null, webMethod.Get).done(function (e) {
                console.log(e);
                if (e.Success) {
                    $('#gv-subject').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: e.Content, pageSize: 10 }));
                }
                else {
                    sweetAlert('something went wrong', '', 'error');
                }
            });
        },
        readSingle: function (e) {
            new apiConnector().callservice('/api/Subject/SubjectReadSingle?id=' + e, null, webMethod.Get).done(function (e) {
                console.log(e);
                if (e.Success) {
                    var subjectViewViewModel = {
                        subjectName: e.Content.subjectVieModel.Name,
                        fee: e.Content.subjectVieModel.Fee,
                        subjectId: e.Content.subjectVieModel.SubjectId
                    };
                    subject.renderModelTemplate(subjectViewViewModel);
                    subject.renderTagGrid(e.Content.subjectModuleList);
                }
                else {
                    sweetAlert('something went wrong', '', 'error');
                }
            });
        },
        update: function (e) { },
        delete: function (e) { },
        create: function (e) {
            swal({
                title: "Are you sure?",
                text: "Do you want to Save?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes",
                closeOnConfirm: false
            }, function () {
                var data = {
                    subjectVieModel: { Name: $('#txtStuedntName').val(), Fee: Number($('#txtFee').val()) },
                    subjectModels: ['a', 'b', 'c']
                };
                new apiConnector().callservice('/api/Subject/SubjectCreate', { item: data }, webMethod.Post).done(function (e) {
                    if (e.Success) {
                        sweetAlert('Success', 'Success', 'success');
                    }
                    else {
                        sweetAlert('something went wrong', '', 'error');
                    }
                });
            });
        },
        renderModelTemplate: function (e) {
            var template = kendo.template($("#template-subject-update").html());
            $('#model-content').html(template(e));
            $('#btnModelAction').attr('data-bind', Number(modelAction.SubjectCreate));
            $("#txtFee").kendoNumericTextBox({
                format: "c",
                decimals: 3
            });
            $('#btnAddTag').on('click', function () {
                subject.addTags($.trim($('#txtModules').val()), 'a');
                $('#txtModules').val('');
            });
            $('#gv-tagLists').kendoGrid({
                columns: [
                    { field: 'name', title: 'Module Name' },
                    {
                        field: 'Action',
                        command: [
                            {
                                name: "delete",
                                click: function (e) {
                                    var tr = $(e.target).closest("tr"); // get the current table row (tr)
                                    var d;
                                    d = $('#gv-tagLists').data('kendoGrid').dataItem(tr);
                                    subject.addTags('', 'r', d.name);
                                }
                            }
                        ]
                    }
                ],
                pageable: true
            });
            $('#model-action').modal('show');
        },
        renderControllers: function (e) {
            var template = kendo.template($("#template-subject").html());
            $('#main-placeHolder').html(template({}));
            subject.initControls();
        },
        addTags: function (e, type, element) {
            var arr = JSON.parse($('#hndTagList').val());
            if (type === 'a') {
                arr.push({ name: e });
            }
            else {
                var index = 0;
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i].name === element) {
                        index = i;
                        break;
                    }
                }
                arr = arr.splice(index, 1);
            }
            $('#hndTagList').val(JSON.stringify(arr));
            $('#gv-tagLists').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: arr, pageSize: 3 }));
        },
        renderTagGrid: function (e) {
            var arr = [];
            $.each(e, function (i, d) {
                arr.push({ name: d });
            });
            $('#gv-tagLists').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: arr, pageSize: 3 }));
            $('#hndTagList').val(JSON.stringify(arr));
        }
    };
    (function (webMethod) {
        webMethod[webMethod["Get"] = 0] = "Get";
        webMethod[webMethod["Post"] = 1] = "Post";
    })(Master.webMethod || (Master.webMethod = {}));
    var webMethod = Master.webMethod;
    var modelAction;
    (function (modelAction) {
        modelAction[modelAction["StudentUpdate"] = 0] = "StudentUpdate";
        modelAction[modelAction["StudentCreate"] = 1] = "StudentCreate";
        modelAction[modelAction["StudentSubjectRegister"] = 2] = "StudentSubjectRegister";
        modelAction[modelAction["SubjectCreate"] = 3] = "SubjectCreate";
        modelAction[modelAction["SubjectUpdate"] = 4] = "SubjectUpdate";
    })(modelAction || (modelAction = {}));
    var apiConnector = (function () {
        function apiConnector() {
        }
        apiConnector.prototype.callservice = function (url, data, method) {
            var dfd = jQuery.Deferred();
            $.ajax({
                url: url,
                method: (method == webMethod.Get) ? "GET" : "POST",
                contentType: "application/json; charset=utf-8",
                data: (method == webMethod.Get) ? data : JSON.stringify(data),
                dataType: "json",
                cache: false,
                success: function (data) {
                    var value = data;
                    dfd.resolve(value);
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(textStatus);
                    dfd.reject();
                }
            });
            return dfd;
        };
        return apiConnector;
    }());
    Master.apiConnector = apiConnector;
})(Master || (Master = {}));
//# sourceMappingURL=master.js.map