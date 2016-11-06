module Master {

    $(() => {

        student.init();
        $('#menu-student').on('click', () => {
            student.init();
        });
        $('#menu-subject').on('click', () => {
            subject.init();
        });
        $('#btnModelAction').on('click', (e) => {
            var ac = Number($(e.target).attr('data-bind'));
            if (ac == Number(modelAction.StudentCreate)) {
                student.create();
            } else if (ac == Number(modelAction.StudentUpdate)) {
                student.update();
            } else if (ac == Number(modelAction.StudentSubjectRegister)) {
                student.saveStudentSubject();
            } else if (modelAction.SubjectCreate) {
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
        init: (e?) => {
            student.renderControllers();
            student.read();
        },
        initControls: (e?) => {
            $('#btnAddStudent').on('click', () => {
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
                }
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
                                click: (e) => {
                                    var tr = $(e.target).closest("tr");
                                    var d: any;
                                    d = $('#gv-student').data('kendoGrid').dataItem(tr);
                                    student.readSingle(d.StudentId);
                                }
                            }, {
                                name: "subjects",
                                click: (e) => {
                                    var tr = $(e.target).closest("tr");
                                    var d: any;
                                    d = $('#gv-student').data('kendoGrid').dataItem(tr);
                                    student.renderStudentSubjectTemplate(d.StudentId);
                                }
                            },
                            {
                                name: "remove",
                                click: (e) => {
                                    var tr = $(e.target).closest("tr");
                                    var d: any;
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
        read: (e?) => {
            new apiConnector().callservice('/api/Student/StudentRead', null, webMethod.Get).done((e) => {
                console.log(e);
                $('#gv-student').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: e.Content, pageSize: 10 }));
            });
        },
        readSingle: (e?) => {
            new apiConnector().callservice('/api/Student/StudentReadSingle?id=' + e, null, webMethod.Get).done((e) => {
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
                } else {
                    swal("something went wrong", '', 'error');
                }
            });
        },
        update: (e?) => {
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
            new apiConnector().callservice('/api/Student/StudentUpdate', data, webMethod.Post).done((e) => {
                console.log(e);
                if (e.Success) {
                    swal("Success !", "Student Update is success", "success")
                    $('#model-action').modal('hide');
                    student.read();
                } else {
                    sweetAlert("Oops...", "Something went wrong!", "error");
                }
            });
        },
        delete: (e?) => {
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
                new apiConnector().callservice('/api/Student/StudentDelete', data, webMethod.Post).done((e) => {
                    console.log(e);
                    if (e.Success) {
                        swal("Success !", "Student Delete is success", "success")
                        student.read();
                    } else {
                        sweetAlert("Oops...", "Something went wrong!", "error");
                    }
                });
            });
        },
        create: (e?) => {
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
            new apiConnector().callservice('/api/Student/StudentCreate', data, webMethod.Post).done((e) => {
                console.log(e);
                if (e.Success) {
                    //TsMessage.ShowSuccess("Student create is success");
                    $('#model-action').modal('hide');
                    student.read();
                }
            });
        },
        renderControllers: (e?) => {
            var template = kendo.template($("#template-student").html());
            $('#main-placeHolder').html(template({}));
            student.initControls();
        },
        renderModelTemplate: (e?) => {
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
                complete: (e) => {
                    console.log(e);
                }
            });
        },
        renderStudentSubjectTemplate: (e?) => {
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
                                click: (e) => {
                                    var tr = $(e.target).closest("tr");
                                    var d: any;
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
            $('#btnAddSubjectToStudent').on('click', () => {
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
            new apiConnector().callservice('/api/Student/StudentSubjectList?studentId=' + e, null, webMethod.Get).done((e) => {
                console.log(e);
                if (e.Success) {
                    $('#studentSubjectList').val(JSON.stringify(e.Content));
                    $('#gv-student-subject-Studentview').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: e.Content, pageSize: 5 }));
                    student.readSubjectList();
                } else {
                    sweetAlert('something went wrong', '', 'error');
                }
            });
        },
        readSubjectList: () => {
            new apiConnector().callservice('/api/Subject/SubjectRead', null, webMethod.Get).done((e) => {
                if (e.Success) {
                    var arr = [];
                    $.each(e.Content, (i, d) => {
                        arr.push({ text: d.Name + ' - $' + d.Fee, value: d.SubjectId });
                    })
                    $('#ddSubject').data('kendoComboBox').setDataSource(new kendo.data.DataSource({ data: arr }));
                } else {
                    sweetAlert('something went wrong', 'cannot read subject list', 'error');
                }
            });
        },
        saveStudentSubject: (e?) => {
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
                $.each(arr, (i, d) => {
                    subjects.push(Number(d.SubjectId));
                });

                new apiConnector().callservice('/api/Student/AddStudentSubject', { studentId: Number($('#hndStudentId2').val()), subjectId: subjects }, webMethod.Post).done((e) => {
                    if (e.Success) {
                        sweetAlert('Success', 'Success', 'success');
                    } else {
                        sweetAlert('something went wrong', 'cannot read subject list', 'error');
                    }
                });
            });

        },
    }

    /////////////////////////
    //////////// SUBJECT
    /////////////////////////
    var subject = {

        init: (e?) => {
            subject.renderControllers();
            subject.read();
        },
        initControls: (e?) => {
            $('#btnAddSubject').on('click', () => {
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
                                click: (e) => {
                                    console.log(e);
                                    var tr = $(e.target).closest("tr");
                                    var d: any;
                                    d = $('#gv-subject').data('kendoGrid').dataItem(tr);
                                    subject.readSingle(d.SubjectId);
                                }
                            },
                            {
                                name: "destroy",
                                click: (e) => {

                                }
                            }
                        ]
                    },
                ],
                noRecords: "<h3> no recodes avaiable.</h3>",
                filterable: true,

            });
        },
        read: (e?) => {
            new apiConnector().callservice('/api/Subject/SubjectRead', null, webMethod.Get).done((e) => {
                console.log(e);
                if (e.Success) {
                    $('#gv-subject').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: e.Content, pageSize: 10 }));
                } else {
                    sweetAlert('something went wrong', '', 'error');
                }
            });
        },
        readSingle: (e?) => {
            new apiConnector().callservice('/api/Subject/SubjectReadSingle?id=' + e, null, webMethod.Get).done((e) => {
                console.log(e);
                if (e.Success) {
                    var subjectViewViewModel = {
                        subjectName: e.Content.subjectVieModel.Name,
                        fee: e.Content.subjectVieModel.Fee,
                        subjectId: e.Content.subjectVieModel.SubjectId
                    };
                    subject.renderModelTemplate(subjectViewViewModel);
                    subject.renderTagGrid(e.Content.subjectModuleList);
                } else {
                    sweetAlert('something went wrong', '', 'error');
                }
            });
        },
        update: (e?) => { },
        delete: (e?) => { },
        create: (e?) => {
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
                new apiConnector().callservice('/api/Subject/SubjectCreate', { item: data }, webMethod.Post).done((e) => {
                    if (e.Success) {
                        sweetAlert('Success', 'Success', 'success');
                    } else {
                        sweetAlert('something went wrong', '', 'error');
                    }
                });
            });
        },
        renderModelTemplate: (e?) => {
            var template = kendo.template($("#template-subject-update").html());
            $('#model-content').html(template(e));
            $('#btnModelAction').attr('data-bind', Number(modelAction.SubjectCreate));
            $("#txtFee").kendoNumericTextBox({
                format: "c",
                decimals: 3
            });
            $('#btnAddTag').on('click', () => {
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
                                click: (e) => {
                                    var tr = $(e.target).closest("tr"); // get the current table row (tr)
                                    var d: any;
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
        renderControllers: (e?) => {
            var template = kendo.template($("#template-subject").html());
            $('#main-placeHolder').html(template({}));
            subject.initControls();
        },
        addTags: (e?, type?, element?) => {
            var arr = JSON.parse($('#hndTagList').val());
            if (type === 'a') {
                arr.push({ name: e });
            } else {
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
        renderTagGrid: (e?) => {
            var arr = [];
            $.each(e, (i, d) => {
                arr.push({ name: d });
            });
            $('#gv-tagLists').data('kendoGrid').setDataSource(new kendo.data.DataSource({ data: arr, pageSize: 3 }));
            $('#hndTagList').val(JSON.stringify(arr));
        }
    }

    export enum webMethod {
        Get = 0,
        Post = 1
    }
    enum modelAction {
        StudentUpdate = 0,
        StudentCreate = 1,
        StudentSubjectRegister = 2,
        SubjectCreate = 3,
        SubjectUpdate = 4
    }
    export class apiConnector {
        callservice(url: string, data: any, method: webMethod): JQueryDeferred<any> {
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
        }
    }
}