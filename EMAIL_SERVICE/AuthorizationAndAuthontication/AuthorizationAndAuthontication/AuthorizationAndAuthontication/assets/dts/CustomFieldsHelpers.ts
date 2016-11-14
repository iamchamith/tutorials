
function POPUPGenerateTextBox(name, code, required, placeholder) {
    var texthtml = '<div class="k-edit-label"><label for="{NameID}">{Name}</label></div>' +
        '<div class="k-edit-field" data-container-for="{NameID}">' +
        '<input type="text" name="{NameID}" class="k-input k-textbox"' +
        'data-bind="value:{NameID}" validationMessage="Please enter the {Name}" {Required} placeholder="{Placeholder}"></div>';

    var nameID = "customField" + code;
    texthtml = texthtml.replace(new RegExp("{Name}", 'g'), name);
    texthtml = texthtml.replace(new RegExp("{NameID}", 'g'), nameID);
    if (required) {
        texthtml = texthtml.replace("{Required}", "required");
    } else {
        texthtml = texthtml.replace("{Required}", " ");
    }
    texthtml = texthtml.replace("{Placeholder}", placeholder);

    return texthtml;
}

function POPUPGenerateDropDown(name, code, required, placeholder, dsString) {
    var dropdownhtml = '<div class="k-edit-label"><label for="{NameID}">' +
        '{Name}</label></div><div class="k-edit-field" ' +
        'data-container-for="{NameID}"> <input name="{NameID}"' +
        'data-bind="value:{NameID}" data-value-field="Value" data-text-field="Text"' +
        'data-source="{DataSource}" data-role="dropdownlist"' +
        'data-option-label="{Placeholder}" validationMessage="{Name} is required" {Required} {INDEX}/></div>';

    var objString = "{data: [";
    var defaultIndex = "NONE";
    for (var z = 0; z < dsString.length; z++) {
        if (z == dsString.length - 1) {
            objString = objString + "{Text:'" + dsString[z].Text + "',Value:'" + dsString[z].Value + "'}";
        } else {
            objString = objString + "{Text:'" + dsString[z].Text + "',Value:'" + dsString[z].Value + "'},";
        }
        if (dsString[z].Default) {
            defaultIndex = z.toString();
        }
    }
    objString = objString + "]}";
    var nameID = "customField" + code;
    dropdownhtml = dropdownhtml.replace(new RegExp("{Name}", 'g'), name);
    dropdownhtml = dropdownhtml.replace(new RegExp("{NameID}", 'g'), nameID);
    if (required) {
        dropdownhtml = dropdownhtml.replace("{Required}", "required");
    } else {
        dropdownhtml = dropdownhtml.replace("{Required}", " ");
    }
    dropdownhtml = dropdownhtml.replace("{Placeholder}", placeholder);

    dropdownhtml = dropdownhtml.replace("{DataSource}", objString);
    if (defaultIndex === "NONE") {
        dropdownhtml = dropdownhtml.replace("{INDEX}", " ");
    } else {
        dropdownhtml = dropdownhtml.replace("{INDEX}", 'data-index="' + (defaultIndex + 1) + '"');
    }
    return dropdownhtml;
}

function POPUPGenerateComboBox(name, code, required, placeholder, dsComboString) {
    var comboboxhtml = '<div class="k-edit-label"><label for="{NameID}">' +
        '{Name}</label></div><div class="k-edit-field"' +
        'data-container-for="{NameID}"> <input name="{NameID}" ' +
        'data-bind="value:{NameID}" data-value-field="Value" data-text-field="Text"' +
        'data-source="{DataSource}" data-role="combobox"' +
        'placeholder="{Placeholder}" validationMessage="{Name} is required" type="number" {Required} data-change="POPUPExtendCombo_change" {INDEX}/></div>';

    var objComboString = "{data: [";
    var defaultIndex = "NONE";
    for (var j = 0; j < dsComboString.length; j++) {
        if (j == dsComboString.length - 1) {
            objComboString = objComboString + "{Text:'" + dsComboString[j].Text + "',Value:'" + dsComboString[j].Value + "'}";
        } else {
            objComboString = objComboString + "{Text:'" + dsComboString[j].Text + "',Value:'" + dsComboString[j].Value + "'},";
        }
        if (dsComboString[j].Default) {
            defaultIndex = j.toString();
        }
    }
    objComboString = objComboString + "]}";
    var nameID = "customField" + code;
    comboboxhtml = comboboxhtml.replace(new RegExp("{Name}", 'g'), name);
    comboboxhtml = comboboxhtml.replace(new RegExp("{NameID}", 'g'), nameID);
    if (required) {
        comboboxhtml = comboboxhtml.replace("{Required}", "required");
    } else {
        comboboxhtml = comboboxhtml.replace("{Required}", " ");
    }
    comboboxhtml = comboboxhtml.replace("{Placeholder}", placeholder);

    comboboxhtml = comboboxhtml.replace("{DataSource}", objComboString);
    if (defaultIndex === "NONE") {
        comboboxhtml = comboboxhtml.replace("{INDEX}", " ");
    } else {

        comboboxhtml = comboboxhtml.replace("{INDEX}", 'data-index="' + (defaultIndex) + '"');
    }
    return comboboxhtml;

}
function POPUPExtendCombo_change(e) {
    if (this.selectedIndex == -1) {
        this.value("");

    }
}
function POPUPGenerateCheckBox(name, code, required, dsCheckbox) {
    var checkboxHtml = '<div class="k-edit-label"><label for="{NameID}">{Name}</label></div>' +
        '<div class="k-edit-field" data-container-for="{NameID}">';
    //var nameID = name.replace(/\s/g, '') + code;
    checkboxHtml = checkboxHtml.replace(new RegExp("{Name}", 'g'), name);
    //checkboxHtml = checkboxHtml.replace(new RegExp("{NameID}", 'g'), nameID);

    for (var j = 0; j < dsCheckbox.length; j++) {
        var newcheckbox = '<input type="checkbox" name="{NameID}" class="k-input k-checkbox" value="{Value}"' +
            ' validationMessage="{DName} is required" {Required} {OnClick}"> {Name}<br />';
        var nameID = "customField" + code + "_" + j;
        if (j == 0) {
            checkboxHtml = checkboxHtml.replace(new RegExp("{NameID}", 'g'), nameID);
        }
        newcheckbox = newcheckbox.replace(new RegExp("{DName}", 'g'), name.replace(/\s/g, ''));
        newcheckbox = newcheckbox.replace(new RegExp("{NameID}", 'g'), nameID);
        newcheckbox = newcheckbox.replace(new RegExp("{Name}", 'g'), dsCheckbox[j].Text);
        newcheckbox = newcheckbox.replace(new RegExp("{Value}", 'g'), dsCheckbox[j].Value);

        if (required) {
            if (j == dsCheckbox.length - 1) {
                newcheckbox = newcheckbox.replace("{Required}", "required");
            } else {
                newcheckbox = newcheckbox.replace("{Required}", " ");
            }
            newcheckbox = newcheckbox.replace("{OnClick}", 'onclick="POPUPExtendCheckbox_change(this);');
        } else {
            newcheckbox = newcheckbox.replace("{Required}", " ");
            newcheckbox = newcheckbox.replace("{OnClick}", " ");
        }

        checkboxHtml = checkboxHtml + newcheckbox;
    }

    return checkboxHtml + "</div>";
}
function POPUPExtendCheckbox_change(e) {
    if (!$(e).is(':checked')) {
        if (!$(e).parent().find(':checkbox').is(':checked')) {
            $(e).parent().find(':checkbox :last').prop('required', true);
        }
    } else {
        $(e).parent().find(':checkbox').prop('required', false);
    }
    var aa = e;
}

function POPUPGenerateRadioButton(name, code, required, dsRadioButton) {
    var radiobuttonHtml = '<div class="k-edit-label"><label for="{NameID}">{Name}</label></div>' +
        '<div class="k-edit-field" data-container-for="{NameID}">';

    radiobuttonHtml = radiobuttonHtml.replace(new RegExp("{Name}", 'g'), name);
    var nameID = "customField" + code;
    for (var j = 0; j < dsRadioButton.length; j++) {
        var newradioB = '<input type="radio" name="{NameID}" class="k-input k-radio" value="{Value}"' +
            ' validationMessage="Please enter the {Name}" {Required}  {Checked}> {Name} <br />';
        //var nameID = dsRadioButton[j].Text.replace(/\s/g, '') + code;

        if (j == 0) {
            radiobuttonHtml = radiobuttonHtml.replace(new RegExp("{NameID}", 'g'), nameID);
            newradioB = newradioB.replace("{Checked}", 'checked');
        } else {
            newradioB = newradioB.replace("{Checked}", ' ');
        }
        newradioB = newradioB.replace(new RegExp("{NameID}", 'g'), nameID);
        newradioB = newradioB.replace(new RegExp("{Name}", 'g'), dsRadioButton[j].Text);
        newradioB = newradioB.replace(new RegExp("{Value}", 'g'), dsRadioButton[j].Value);
        if (required) {
            newradioB = newradioB.replace("{Required}", 'required');
        } else {
            newradioB = newradioB.replace("{Required}", " ");
        }

        radiobuttonHtml = radiobuttonHtml + newradioB;
    }

    return radiobuttonHtml + '</div>';
}

function ResetExtendFields(FielsList) {
    for (var o = 0; o < FielsList.length; o++) {
        if (FielsList[o].Type === "textbox") {
            $("input[name='customField" + FielsList[o].Code + "']").val("");
        } else if (FielsList[o].Type === "dropdown") {
            var dropinput = $("input[name='customField" + FielsList[o].Code + "']");
            $(dropinput).data("kendoDropDownList").select(0);
        } else if (FielsList[o].Type === "combobox") {
            var combinput = $("input[name='customField" + FielsList[o].Code + "']");
            $(combinput).data("kendoComboBox").value("");
        } else if (FielsList[o].Type === "checkbox") {
            $("input[name^='customField" + FielsList[o].Code + "']").prop("checked", false);
        } else if (FielsList[o].Type === "radiobox") {
            $("input[name='customField" + FielsList[o].Code + "']").prop("checked", false);
        }
    }
}

function GetNewExtendFieldsValList(FielsList) {
    var ExtendedValues = [];
    for (var o = 0; o < FielsList.length; o++) {
        if (FielsList[o].Type === "textbox") {
            var tvalList = [];
            tvalList.push($("input[name='customField" + FielsList[o].Code + "']").val().trim());
            ExtendedValues.push({
                LinkTablePK: "",
                LinkTable: "",
                ExtendedCode: FielsList[o].Code,
                Value: tvalList,
                PageName: "RecreationUserRelationships"
            });
        } else if (FielsList[o].Type === "dropdown") {
            var dropinput = $("input[name='customField" + FielsList[o].Code + "']");
            var dvalList = [];
            dvalList.push($(dropinput).data("kendoDropDownList").value());
            ExtendedValues.push({
                LinkTablePK: "",
                LinkTable: "",
                ExtendedCode: FielsList[o].Code,
                Value: dvalList,
                PageName: "RecreationUserRelationships"
            });

        } else if (FielsList[o].Type === "combobox") {
            var combinput = $("input[name='customField" + FielsList[o].Code + "']");
            var cvalList = [];
            cvalList.push($(combinput).data("kendoComboBox").value());
            ExtendedValues.push({
                LinkTablePK: "",
                LinkTable: "",
                ExtendedCode: FielsList[o].Code,
                Value: cvalList,
                PageName: "RecreationUserRelationships"
            });

        } else if (FielsList[o].Type === "checkbox") {
            var checkinput = $("input[name^='customField" + FielsList[o].Code + "']:checked");
            var valList = [];
            checkinput.each(function (i, v) {
                valList.push($(v).attr("value").trim());
            });
            ExtendedValues.push({
                LinkTablePK: "",
                LinkTable: "",
                ExtendedCode: FielsList[o].Code,
                Value: valList,
                PageName: "RecreationUserRelationships"
            });

        } else if (FielsList[o].Type === "radiobox") {
            var rvalList = [];
            if ($("input[name='customField" + FielsList[o].Code + "']:required").length > 0) {
                if (!$("input[name='customField" + FielsList[o].Code + "']:required").is(':checked')) {
                    return null;
                }
            }
            if ($("input[name='customField" + FielsList[o].Code + "']:checked").length > 0) {
                rvalList.push($("input[name='customField" + FielsList[o].Code + "']:checked").val().trim());
                ExtendedValues.push({
                    LinkTablePK: "",
                    LinkTable: "",
                    ExtendedCode: FielsList[o].Code,
                    Value: rvalList,
                    PageName: "RecreationUserRelationships"
                });
            }
        }
    }

    return ExtendedValues;
}

function ApplyOldExtendFieldsValList(FielsList, e) {
    if (e.model.ExtendedValues) {
        if (e.model.ExtendedValues.length > 0) {
            ResetExtendFields(FielsList);
            for (var ex = 0; ex < e.model.ExtendedValues.length; ex++) {
                var inputElement = $("input[name='customField" + e.model.ExtendedValues[ex].ExtendedCode + "']");
                if (inputElement.attr("data-role")) {
                    if (inputElement.attr("data-role") === "dropdownlist") {
                        if (e.model.ExtendedValues[ex].Value.length > 0) {
                            $(inputElement).data("kendoDropDownList").select(function (dataItem) {
                                return dataItem.Value === e.model.ExtendedValues[ex].Value[0];
                            });
                        } else {
                            $(inputElement).data("kendoDropDownList").select(0);
                        }
                    } else if (inputElement.attr("data-role") === "combobox") {
                        if (e.model.ExtendedValues[ex].Value.length > 0) {
                            $(inputElement).data("kendoComboBox").select(function (dataItem) {
                                return dataItem.Value === e.model.ExtendedValues[ex].Value[0];
                            });
                        } else {
                            $(inputElement).data("kendoComboBox").value("");
                        }

                    }
                } else {
                    if (inputElement.attr("type") === "text") {
                        if (e.model.ExtendedValues[ex].Value.length > 0) {
                            inputElement.val(e.model.ExtendedValues[ex].Value[0]);
                        }
                    } else if (inputElement.attr("type") === "radio") {
                        inputElement.each(function (k, v) {
                            if (e.model.ExtendedValues[ex].Value.length > 0) {
                                if ($(v).attr("value").trim() === e.model.ExtendedValues[ex].Value[0]) {
                                    $(v).prop('checked', true);
                                } else {
                                    $(v).prop('checked', false);
                                }
                            } else {
                                $(v).prop('checked', false);
                            }

                        });
                    } else {
                        var inputcheckbox = $("input[name^='customField" + e.model.ExtendedValues[ex].ExtendedCode + "']");
                        if (e.model.ExtendedValues[ex].Value.length > 0) {
                            $("input[name^='customField" + e.model.ExtendedValues[ex].ExtendedCode + "']").prop("checked", false);
                            $("input[name^='customField" + e.model.ExtendedValues[ex].ExtendedCode + "']").prop("required", false);
                            for (var ev = 0; ev < e.model.ExtendedValues[ex].Value.length; ev++) {
                                inputcheckbox.each(function (k, v) {
                                    if ($(v).attr("value").trim() === e.model.ExtendedValues[ex].Value[ev]) {
                                        $(v).prop('checked', true);
                                    }
                                });
                            }
                        } else {
                            $("input[name^='customField" + e.model.ExtendedValues[ex].ExtendedCode + "']").prop("checked", false);
                        }

                    }

                }
            }
        } else {
            ResetExtendFields(FielsList);
        }
    }
}

