﻿var arrayList = [];
var dropdownLength = $('.drpTransactionLayout').length;

//Get data of configuration grid on document load.
$(function () {
    $('.drpTransactionLayout').each(function () {
        if (ValidateDataJS($(this).val()))
            GetData($(this).val())
    })
    setTimeout(function () {
        BindEditData();
    }, 1000)
})

//Validate data is null or not 
function ValidateDataJS(value) {
    if (value == null || value == '' || value == undefined)
        return false;
    return true;
}

//Get grid data by id
function GetData(value) {
    if (value) {
        $.ajax({
            url: '/TransactionGrid/GetGridDetailsById',
            type: 'GET',
            dataType: 'json',
            data: { Id: value },
            success: function (data) {
                if (arrayList == null || arrayList.length <= 0)
                    arrayList.push(data);
                else {
                    var isAllowed = true;
                    for (var x = 0; x < arrayList.length; x++) {
                        if (arrayList[x].gridTransactionId == data.gridTransactionId)
                            isAllowed = false;
                    }
                    if (isAllowed)
                        arrayList.push(data);
                }
                console.log(arrayList);
                Configure();
            },
            failure: function (response) {
                errorMessage(response);
            }
        });
    }
}

//Dropdown value change call ajax and get grid configuration data
$('.drpTransactionLayout').change(function () {
    if ($(this).val()) {
        GetData($(this).val());
    }
})

//Configure
function Configure() {
    for (var x = 0; x < arrayList.length; x++) {

        var tableHTML = `<thead style='` + arrayList[x].style + `'><tr><th style='min-width:30px !important;max-width:30px !important'><input type="checkbox" class="chkTransactionGrid" style="height:15px;width:15px" onclick="CheckAll(this);" /></th><th style='min-width:60px !important;max-width:60px !important'>Sr.No</th>`;
        if (arrayList[x].transactionList.length > 0) {
            for (var y = 0; y < arrayList[x].transactionList.length; y++) {

                //If column is hide
                var display = ``;
                if (arrayList[x].transactionList[y].hideYN) {
                    display = `display:none !important;`
                }

                tableHTML += `<th style='
                                    min-width:` + arrayList[x].transactionList[y].width + `px !important;
                                    max-width:` + arrayList[x].transactionList[y].width + `px !important;
                                    ` + arrayList[x].transactionList[y].style + `
                                    ` + display + `'>
                                    ` + arrayList[x].transactionList[y].tableHeaderName +
                    `</th>`
            }
            tableHTML += `</tr></thead>`;
        }
        $('#' + arrayList[x].tableId).html(tableHTML);
        $('#' + arrayList[x].tableId).attr('data-id', arrayList[x].gridTransactionId);
        //$('#' + arrayList[x].tableId).attr('style', arrayList[x].style);
    }

}

//Add row data to grid
function AddDataToGrid() {
    var existingSrNo = $('input[name="transactionGridSrNo"]').val();
    if (ValidateDataJS(existingSrNo) && parseInt(existingSrNo) > 0) {
        //Edit scenario
        for (var x = 0; x < arrayList.length; x++) {
            var tr;
            $('#' + arrayList[x].tableId).children('tbody').children('tr').each(function () {
                if ($(this).children('td').eq(1).html() == existingSrNo) {
                    tr = $(this);
                    return false;
                }
            })

            var isAllow = true;

            for (var y = 0; y < arrayList[x].transactionList.length; y++) {

                //For Textbox
                if (arrayList[x].transactionList[y].type == "1" && isAllow) {
                    var textboxName = arrayList[x].transactionList[y].fieldName;
                    var textboxValue = $('input[name="' + textboxName + '"]').val();
                    var isRequired = $('input[name="' + textboxName + '"]').attr('required');

                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(textboxValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        $(tr).children('td').eq(parseInt(y) + 2).html(textboxValue);
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }


                //For dropdown
                if (arrayList[x].transactionList[y].type == "2" && isAllow) {
                    var selectName = arrayList[x].transactionList[y].fieldName;
                    var selectValue = $('select[name="' + selectName + '"]').val();
                    var isRequired = $('select[name="' + selectName + '"]').attr('required');
                    var selectHTML = $('select[name="' + selectName + '"]').children('option:selected').html();
                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(selectValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        $(tr).children('td').eq(parseInt(y) + 2).html(selectHTML);
                        $(tr).children('td').eq(parseInt(y) + 2).attr('data-attr', selectValue);
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }

                //For Radio
                if (arrayList[x].transactionList[y].type == "3" && isAllow) {
                    var textboxName = arrayList[x].transactionList[y].fieldName;
                    var textboxValue = $('input[name="' + textboxName + '"]:checked').val();
                    var isRequired = $('input[name="' + textboxName + '"]').attr('required');
                    var textHTML = '';
                    if ($('input[name="' + textboxName + '"]:checked').closest('label').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').closest('label').html();
                    else if ($('input[name="' + textboxName + '"]:checked').closest('span').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').closest('span').html();
                    else if ($('input[name="' + textboxName + '"]:checked').closest('p').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').closest('p').html();
                    else if ($('input[name="' + textboxName + '"]:checked').parent().children('label').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').parent().children('label').html();
                    else if ($('input[name="' + textboxName + '"]:checked').parent().children('span').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').parent().children('span').html();
                    else if ($('input[name="' + textboxName + '"]:checked').parent().children('p').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').parent().children('p').html();

                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(textboxValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        $(tr).children('td').eq(parseInt(y) + 2).html(textHTML);
                        $(tr).children('td').eq(parseInt(y) + 2).attr('data-attr', textboxValue);

                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }

                //For Checkbox
                if (arrayList[x].transactionList[y].type == "4" && isAllow) {
                    var textboxName = arrayList[x].transactionList[y].fieldName;
                    var textboxValue = '';
                    $('input[name="' + textboxName + '"]:checked').each(function () {
                        textboxValue += $(this).val() + ",";
                    });
                    var isRequired = $('input[name="' + textboxName + '"]').attr('required');
                    var textHTML = '';

                    $('input[name="' + textboxName + '"]:checked').each(function () {
                        if ($(this).closest('label').length > 0) {
                            textHTML += $(this).closest('label').html() + ",";
                        }
                        else if ($(this).closest('span').length > 0) {
                            textHTML += $(this).closest('span').html() + ",";
                        }
                        else if ($(this).closest('p').length > 0) {
                            textHTML += $(this).closest('p').html() + ",";
                        }
                        else if ($(this).parent().children('label').length > 0) {
                            textHTML += $(this).parent().children('label').html() + ",";
                        }
                        else if ($(this).parent().children('span').length > 0) {
                            textHTML += $(this).parent().children('span').html() + ",";
                        }
                        else if ($(this).parent().children('p').length > 0) {
                            textHTML += $(this).parent().children('p').html() + ",";
                        }
                    })

                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(textboxValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        $(tr).children('td').eq(parseInt(y) + 2).html(textHTML.replace(/,\s*$/, ""));
                        $(tr).children('td').eq(parseInt(y) + 2).attr('data-attr', textboxValue);
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }

                //For Textarea
                if (arrayList[x].transactionList[y].type == "5" && isAllow) {
                    var textboxName = arrayList[x].transactionList[y].fieldName;
                    var textboxValue = $('textarea[name="' + textboxName + '"]').val();
                    var isRequired = $('textarea[name="' + textboxName + '"]').attr('required');
                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(textboxValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        $(tr).children('td').eq(parseInt(y) + 2).html(textboxValue);
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }
            }
        }
        CalculateTotal();
        ClearTextbox();
    }
    else {
        //Add row scenario

        for (var x = 0; x < arrayList.length; x++) {
            var length = $('#' + arrayList[x].tableId).children('tbody').children('tr:not(.totalRow)').length;
            var srNo = parseInt(length) + 1;
            var tableRowHTML = `<tr><td style='min-width:30px !important; max-width:30px !important'><input type='checkbox' class='chkTransactionGrid' style="height:15px;width:15px"/></td><td class="transactionGridTd" style='min-width:60px !important; max-width:60px !important'>` + srNo + `</td>`;
            var isAllow = true;

            for (var y = 0; y < arrayList[x].transactionList.length; y++) {

                var style = 'min-width:' + arrayList[x].transactionList[y].width + 'px !important;max-width:' + arrayList[x].transactionList[y].width + 'px !important;';

                if (arrayList[x].transactionList[y].canGridYN == '1' || arrayList[x].transactionList[y].canGridYN)
                    style += 'white-space:normal;'
                else
                    style += 'text-overflow:ellipsis;overflow:hidden;'

                if (arrayList[x].transactionList[y].style)
                    style += arrayList[x].transactionList[y].style;

                if (arrayList[x].transactionList[y].hideYN == '1' || arrayList[x].transactionList[y].hideYN)
                    style += 'display:none;'

                if (arrayList[x].transactionList[y].align == '1')
                    style += 'text-align:left;'

                else if (arrayList[x].transactionList[y].align == '2')
                    style += 'text-align:right;'

                else if (arrayList[x].transactionList[y].align == '3')
                    style += 'text-align:center;'

                //For Textbox
                if (arrayList[x].transactionList[y].type == "1" && isAllow) {
                    var textboxName = arrayList[x].transactionList[y].fieldName;
                    var textboxValue = $('input[name="' + textboxName + '"]').val();
                    var isRequired = $('input[name="' + textboxName + '"]').attr('required');

                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(textboxValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        tableRowHTML += `<td class="transactionGridTd" data-field-type='1' data-field-name='` + textboxName + `' style= '` + style + `'>` + textboxValue + `</td>`
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }

                //For dropdown
                if (arrayList[x].transactionList[y].type == "2" && isAllow) {
                    var selectName = arrayList[x].transactionList[y].fieldName;
                    var selectValue = $('select[name="' + selectName + '"]').val();
                    var isRequired = $('select[name="' + selectName + '"]').attr('required');
                    var selectHTML = $('select[name="' + selectName + '"]').children('option:selected').html();
                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(selectValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        tableRowHTML += `<td class="transactionGridTd" data-field-type='2' data-field-name='` + selectName + `' style='` + style + `' data-attr='` + selectValue + `'>` + selectHTML + `</td>`
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }

                //For Radio
                if (arrayList[x].transactionList[y].type == "3" && isAllow) {
                    var textboxName = arrayList[x].transactionList[y].fieldName;
                    var textboxValue = $('input[name="' + textboxName + '"]:checked').val();
                    var isRequired = $('input[name="' + textboxName + '"]').attr('required');
                    var textHTML = '';
                    if ($('input[name="' + textboxName + '"]:checked').closest('label').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').closest('label').html();
                    else if ($('input[name="' + textboxName + '"]:checked').closest('span').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').closest('span').html();
                    else if ($('input[name="' + textboxName + '"]:checked').closest('p').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').closest('p').html();
                    else if ($('input[name="' + textboxName + '"]:checked').parent().children('label').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').parent().children('label').html();
                    else if ($('input[name="' + textboxName + '"]:checked').parent().children('span').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').parent().children('span').html();
                    else if ($('input[name="' + textboxName + '"]:checked').parent().children('p').length > 0)
                        textHTML = $('input[name="' + textboxName + '"]:checked').parent().children('p').html();

                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(textboxValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        tableRowHTML += `<td class="transactionGridTd" data-field-type='3' data-field-name='` + textboxName + `' style= '` + style + `' data-attr='` + textboxValue + `'>` + textHTML + `</td>`
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }

                //For Checkbox
                if (arrayList[x].transactionList[y].type == "4" && isAllow) {
                    var textboxName = arrayList[x].transactionList[y].fieldName;
                    var textboxValue = '';
                    $('input[name="' + textboxName + '"]:checked').each(function () {
                        textboxValue += $(this).val() + ",";
                    });
                    var isRequired = $('input[name="' + textboxName + '"]').attr('required');
                    var textHTML = '';

                    $('input[name="' + textboxName + '"]:checked').each(function () {
                        if ($(this).closest('label').length > 0) {
                            textHTML += $(this).closest('label').html() + ",";
                        }
                        else if ($(this).closest('span').length > 0) {
                            textHTML += $(this).closest('span').html() + ",";
                        }
                        else if ($(this).closest('p').length > 0) {
                            textHTML += $(this).closest('p').html() + ",";
                        }
                        else if ($(this).parent().children('label').length > 0) {
                            textHTML += $(this).parent().children('label').html() + ",";
                        }
                        else if ($(this).parent().children('span').length > 0) {
                            textHTML += $(this).parent().children('span').html() + ",";
                        }
                        else if ($(this).parent().children('p').length > 0) {
                            textHTML += $(this).parent().children('p').html() + ",";
                        }
                    })

                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(textboxValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        tableRowHTML += `<td class="transactionGridTd" data-field-type='4'  data-field-name='` + textboxName + `' style= '` + style + `' data-attr='` + textboxValue + `'>` + textHTML.replace(/,\s*$/, ""); + `</td>`
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }

                //For Textarea
                if (arrayList[x].transactionList[y].type == "5" && isAllow) {
                    var textboxName = arrayList[x].transactionList[y].fieldName;
                    var textboxValue = $('textarea[name="' + textboxName + '"]').val();
                    var isRequired = $('textarea[name="' + textboxName + '"]').attr('required');
                    if (ValidateDataJS(isRequired)) // Check required attribute exists
                        if (!ValidateDataJS(textboxValue)) // Check value exists or not
                            isAllow = false;

                    if (isAllow) {
                        tableRowHTML += `<td class="transactionGridTd" data-field-type='5' data-field-name='` + textboxName + `' style='` + style + `'>` + textboxValue + `</td>`
                    }
                    else {
                        alert("Please add compulsory fields")
                    }
                }
            }

            tableRowHTML += "</tr>";

            if (isAllow) {
                if ($('#' + arrayList[x].tableId).children('tbody').length > 0) {
                    if ($('#' + arrayList[x].tableId).children('tbody').children('tr.totalRow').length > 0) {
                        $('#' + arrayList[x].tableId).children('tbody').children('tr.totalRow').before(tableRowHTML);
                    }
                    else {
                        $('#' + arrayList[x].tableId).children('tbody').append(tableRowHTML);
                    }

                }
                else
                    $('#' + arrayList[x].tableId).append(`<tbody style='` + arrayList[x].style + `'>` + tableRowHTML + `</tbody>`);

                CalculateTotal();
            }
        }

        ClearTextbox();

        $('.transactionGridTd').click(function () {
            var tr = $(this).closest('tr');
            var srNo = $(this).closest('tr').children('td').eq(1).html();
            $('input[name="transactionGridSrNo"]').val(srNo);
            $(tr).children('td').each(function () {
                var fieldName = $(this).attr('data-field-name');
                var fieldType = $(this).attr('data-field-type');
                var fieldValue = $(this).attr('data-attr');

                if (fieldType && fieldName) {
                    //For textbox
                    if (fieldType == '1') {
                        $('input[name="' + fieldName + '"]').val($(this).html());
                    }
                    //For Dropdown
                    else if (fieldType == '2') {
                        $('select[name="' + fieldName + '"]').val(fieldValue);
                    }
                    //For radio
                    else if (fieldType == '3') {
                        $('input[name="' + fieldName + '"]').each(function () {
                            $(this).prop('checked', '')
                        })

                        $('input[name="' + fieldName + '"][value="' + fieldValue + '"]').prop('checked', 'checked')
                    }
                    //For checkbox
                    else if (fieldType == '4') {
                        $('input[name="' + fieldName + '"]').each(function () {
                            $(this).prop('checked', '')
                        })

                        var splitted = fieldValue.toString().split(',');
                        if (splitted != null && splitted.length > 0) {
                            for (var g = 0; g < splitted.length; g++) {
                                $('input[name="' + fieldName + '"][value="' + splitted[g] + '"]').prop('checked', 'checked')
                            }
                        }
                    }
                    //For textarea
                    else if (fieldType == '5') {
                        $('textarea[name="' + fieldName + '"]').val($(this).html());
                    }
                }

            })
        })
    }
}

//Clear data
function ClearTextbox() {
    for (var x = 0; x < arrayList.length; x++) {

        for (var y = 0; y < arrayList[x].transactionList.length; y++) {

            //For Textbox
            if (arrayList[x].transactionList[y].type == "1") {
                var textboxName = arrayList[x].transactionList[y].fieldName;
                $('input[name="' + textboxName + '"]').val('');
            }

            //For dropdown
            if (arrayList[x].transactionList[y].type == "2") {
                var selectName = arrayList[x].transactionList[y].fieldName;
                $('select[name="' + selectName + '"]').val('0');
            }

            //For Radio/Checkbox
            if (arrayList[x].transactionList[y].type == "3" || arrayList[x].transactionList[y].type == "4") {
                var textboxName = arrayList[x].transactionList[y].fieldName;
                $('input[name="' + textboxName + '"]').each(function () {
                    $(this).prop('checked', '');
                })
            }

            //For Textarea
            if (arrayList[x].transactionList[y].type == "5") {
                var textboxName = arrayList[x].transactionList[y].fieldName;
                $('textarea[name="' + textboxName + '"]').val('');
            }
        }
    }

    $('input[name="transactionGridSrNo"]').val('');
}

//Check All Checkbox
function CheckAll(obj) {
    if ($(obj).is(":checked")) {
        $(obj).closest('thead').next().children('tr').each(function () {
            $(this).children('td').eq(0).children('input').prop('checked', 'checked');
        })
    }
    else {
        $(obj).closest('thead').next().children('tr').each(function () {
            $(this).children('td').eq(0).children('input').prop('checked', '');
        })
    }

}

//Delete Confirmation
function DeleteConfirmation(obj) {
    if (confirm("Are you sure want to delete selected rows?")) {

        $(obj).parent().parent().next().children('table').children('tbody').children('tr').each(function () {
            if ($(this).children('td').eq(0).children('input').is(":checked")) {
                $(this).remove();
            }
        })

        var srNo = 1;
        $(obj).parent().parent().next().children('table').children('tbody').children('tr').each(function () {
            $(this).children('td').eq(1).html(srNo);
            srNo = parseInt(srNo) + 1;
        })

        $(obj).parent().parent().next().children('table').children('thead').children('tr').children('th').eq(0).children('input').prop('checked', '');
        CalculateTotal();
    }
}

//Edit Row
function EditRow(srNo) {
    if (arrayList.length == dropdownLength) {
        for (var x = 0; x < arrayList.length; x++) {
            $('#' + arrayList[x].tableId).children('tbody').children('tr').each(function () {
                if ($(this).children('td').eq(1).html() == srNo) {
                    $(this).children('td').each(function () {
                        var fieldName = $(this).attr('data-field-name');
                        var fieldType = $(this).attr('data-field-type');
                        var fieldValue = $(this).attr('data-attr');

                        if (fieldType && fieldName) {
                            //For textbox
                            if (fieldType == '1') {
                                $('input[name="' + fieldName + '"]').val($(this).html());
                            }
                            //For Dropdown
                            else if (fieldType == '2') {
                                $('select[name="' + fieldName + '"]').val(fieldValue);
                            }
                            //For radio
                            else if (fieldType == '3') {
                                $('input[name="' + fieldName + '"]').each(function () {
                                    $(this).prop('checked', '')
                                })
                                $('input[name="' + fieldName + '"][value="' + fieldValue + '"]').prop('checked', 'checked')
                            }
                            //For checkbox
                            else if (fieldType == '4') {
                                $('input[name="' + fieldName + '"]').each(function () {
                                    $(this).prop('checked', '')
                                })
                                var splitted = fieldValue.toString().split(',');
                                if (splitted != null && splitted.length > 0) {
                                    for (var g = 0; g < splitted.length; g++) {
                                        $('input[name="' + fieldName + '"][value="' + splitted[g] + '"]').prop('checked', 'checked')
                                    }
                                }
                            }
                            //For textarea
                            else if (fieldType == '5') {
                                $('textarea[name="' + fieldName + '"]').val($(this).html());
                            }
                        }

                    })
                }
            })

        }
    }
}

//Calculate Total
function CalculateTotal() {
    for (var x = 0; x < arrayList.length; x++) {
        var totalArray = new Array(arrayList[x].transactionList.length);

        if (arrayList[x].isTotal == '1' || arrayList[x].isTotal == 'true' || arrayList[x].isTotal == 'True') {
            if ($('#' + arrayList[x].tableId).children('tbody').children('tr.totalRow').length <= 0) {

                var totalRowHTML = `<tr class='totalRow'><td colspan='2' style='text-align:center'><b>Total</b></td>`;

                $('#' + arrayList[x].tableId).children('tbody').children('tr').each(function () {
                    for (var y = 0; y < arrayList[x].transactionList.length; y++) {

                        if ($(this).children('td').eq(parseInt(y) + 2).attr('data-field-name') == arrayList[x].transactionList[y].fieldName) {

                            var style = 'min-width:' + arrayList[x].transactionList[y].width + 'px !important;max-width:' + arrayList[x].transactionList[y].width + 'px !important;';

                            if (arrayList[x].transactionList[y].canGridYN == '1' || arrayList[x].transactionList[y].canGridYN)
                                style += 'white-space:normal;'
                            else
                                style += 'text-overflow:ellipsis;overflow:hidden;'

                            if (arrayList[x].transactionList[y].style)
                                style += arrayList[x].transactionList[y].style;

                            if (arrayList[x].transactionList[y].hideYN == '1' || arrayList[x].transactionList[y].hideYN)
                                style += 'display:none;'

                            if (arrayList[x].transactionList[y].align == '1')
                                style += 'text-align:left;'

                            else if (arrayList[x].transactionList[y].align == '2')
                                style += 'text-align:right;'

                            else if (arrayList[x].transactionList[y].align == '3')
                                style += 'text-align:center;'


                            if (arrayList[x].transactionList[y].totalYN == '1' || arrayList[x].transactionList[y].totalYN == 'true' || arrayList[x].transactionList[y].totalYN == 'True') {

                                if (ValidateDataJS($(this).children('td').eq(parseInt(y) + 2).html()) && parseFloat($(this).children('td').eq(parseInt(y) + 2).html()) > 0) {
                                    totalRowHTML += `<td style='` + style + `'><b>` + $(this).children('td').eq(parseInt(y) + 2).html() + `</b></td>`;
                                }
                                else {
                                    totalRowHTML += `<td style='` + style + `'></td>`
                                }
                            }
                            else {
                                totalRowHTML += `<td style='` + style + `'></td>`
                            }
                        }
                    }
                })
                totalRowHTML += "</tr>";
                $('#' + arrayList[x].tableId).children('tbody').append(totalRowHTML);
            }
            else {
                var tr = $('#' + arrayList[x].tableId).children('tbody').children('tr.totalRow');

                $('#' + arrayList[x].tableId).children('tbody').children('tr:not(.totalRow)').each(function () {
                    for (var y = 0; y < arrayList[x].transactionList.length; y++) {

                        if (arrayList[x].transactionList[y].totalYN == '1' || arrayList[x].transactionList[y].totalYN == 'true' || arrayList[x].transactionList[y].totalYN == 'True') {

                            try {
                                var oldValue = 0;
                                var total = 0;
                                var currentValue = 0;
                                if (ValidateDataJS(totalArray[y]) && parseFloat(totalArray[y]) > 0) {
                                    oldValue = parseFloat(totalArray[y]);
                                }

                                try {
                                    currentValue = parseFloat($(this).children('td').eq(parseInt(y) + 2).html());

                                }
                                catch (err) { }
                                finally {
                                    total = parseFloat(oldValue) + parseFloat(currentValue);
                                    totalArray[y] = total;
                                    $(tr).children('td').eq(parseInt(y) + 1).html(`<b>` + total + `</b>`)
                                }
                            }
                            catch (err) {

                            }
                            finally {

                            }
                        }
                    }
                })


            }
        }
    }
}

//Form submit bind data to object
$('form').submit(function () {

    var isAllowed = true;
    var totalRows = $('#' + arrayList[0].tableId).children('tbody').children('tr:not(.totalRow)').length;

    var saveArray = [];

    for (var x = 0; x < arrayList.length; x++) {
        if ($('#' + arrayList[x].tableId).children('tbody').children('tr:not(.totalRow)').length != totalRows)
            isAllowed = false;
    }

    if (isAllowed) {
        for (var y = 1; y <= totalRows; y++) {

            var objectArray = [];

            for (var x = 0; x < arrayList.length; x++) {
                $('#' + arrayList[x].tableId).children('tbody').children('tr:not(.totalRow)').each(function () {
                    if ($(this).children('td').eq(1).html() == y) {
                        var isSkip = 0;
                        $(this).children('td').each(function () {
                            if (isSkip >= 2) {
                                var fieldName = $(this).attr('data-field-name');
                                var fieldType = $(this).attr('data-field-type');
                                var fieldValue = '';
                                var fieldDisplayValue = '';

                                if (fieldType && fieldName) {
                                    //For textbox
                                    if (fieldType == '1') {
                                        fieldValue = $(this).html();
                                    }
                                    //For Dropdown
                                    else if (fieldType == '2') {
                                        fieldValue = $(this).attr('data-attr');
                                        fieldDisplayValue = $(this).html();
                                    }
                                    //For radio
                                    else if (fieldType == '3') {
                                        fieldValue = $(this).attr('data-attr');
                                        fieldDisplayValue = $(this).html();
                                    }
                                    //For checkbox
                                    else if (fieldType == '4') {
                                        fieldValue = $(this).attr('data-attr');
                                        fieldDisplayValue = $(this).html();
                                        fieldValue = fieldValue.replace(/,\s*$/, "");
                                    }
                                    //For textarea
                                    else if (fieldType == '5') {
                                        fieldValue = $(this).html();
                                    }
                                }

                                objectArray.push({
                                    "Label": fieldName,
                                    "Value": fieldValue,
                                    "DisplayValue": fieldDisplayValue
                                });
                            }
                            isSkip = parseInt(isSkip) + 1;
                        })
                    }

                });
            }

            saveArray.push(objectArray);
        }

        var jsonString = JSON.stringify(saveArray);

        $('#Data').val(jsonString);
    }
})

//Bind edit time data to grid
function BindEditData() {
    var data = $('#Data').val();
    if (ValidateDataJS(data)) {
        var editObject = $.parseJSON(data);
        if (editObject != null && editObject.length > 0) {
            for (var x = 0; x < editObject.length; x++) {
                for (var y = 0; y < editObject[x].length; y++) {
                    for (var z = 0; z < arrayList.length; z++) {
                        for (var a = 0; a < arrayList[z].transactionList.length; a++) {
                            if (editObject[x][y].Label == arrayList[z].transactionList[a].fieldName) {

                                //For Textbox
                                if (arrayList[z].transactionList[a].type == '1') {
                                    $('input[name="' + arrayList[z].transactionList[a].fieldName + '"]').val(editObject[x][y].Value);
                                }

                                //For Dropdown
                                else if (arrayList[z].transactionList[a].type == '2') {
                                    $('select[name="' + arrayList[z].transactionList[a].fieldName + '"]').val(editObject[x][y].Value);
                                }

                                //For Radio
                                else if (arrayList[z].transactionList[a].type == '3') {
                                    $('input[name="' + arrayList[z].transactionList[a].fieldName + '"]').prop('checked', false);
                                    $('input[name="' + arrayList[z].transactionList[a].fieldName + '"][value="' + editObject[x][y].Value + '"]').prop('checked', true);
                                }

                                //For Checkbox
                                else if (arrayList[z].transactionList[a].type == '4') {
                                    var splitted = editObject[x][y].Value.toString().split(',');
                                    if (splitted != null && splitted.length > 0) {
                                        for (var g = 0; g < splitted.length; g++) {
                                            $('input[name="' + arrayList[z].transactionList[a].fieldName + '"][value="' + splitted[g] + '"]').prop('checked', 'checked')
                                        }
                                    }
                                }

                                //For Textarea
                                else if (arrayList[z].transactionList[a].type == '5') {
                                    $('textarea[name="' + arrayList[z].transactionList[a].fieldName + '"').val(editObject[x][y].Value);
                                }
                            }
                        }


                    }
                }

                AddDataToGrid();
            }
            CalculateTotal();
        }
    }

}

