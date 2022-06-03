
//get root url
function getRootUrl() {
    var hostName = "";
    var defaultPorts = { "http:": 80, "https:": 443 };
    hostName = window.location.protocol + "//" + window.location.hostname + (((window.location.port) && (window.location.port != defaultPorts[window.location.protocol])) ? (":" + window.location.port) : "");
    return hostName;
}

$(document).ready(function () {

    //Menu user loged-in
    document.addEventListener("DOMContentLoaded", function () {
        document.querySelectorAll('.dropdown-menu').forEach(function (element) {
            element.addEventListener('click', function (e) {
                e.stopPropagation();
            });
        })
    });

    //Enable Text Editor
    //$('#Content').summernote();

    ////Khởi tạo Tooltip
    //new jBox('Tooltip', {
    //    attach: $("[role=tooltip]"),
    //    trigger: 'mouseenter',
    //    getTitle: 'data-jbox-title',
    //    getContent: 'data-jbox-content'
    //});

    //$('.tooltip').jBox('Tooltip', {
    //    trigger: 'mouseenter',
    //    adjustPosition: true,
    //    adjustTracker: true
    //});

    //$('[data-toggle="tooltip"]').tooltip({
    //    animated: 'fade',
    //    placement: 'top',
    //    html: true
    //});

    //$('a[data-toggle="tooltip"]').tooltip({
    //    animated: 'fade',
    //    placement: 'top',
    //    html: true
    //});

    //$('input#btDeleteCategory').click(function (e)
    //{        
    //    return confirm('Bạn muốn xóa nội dung này phải không?');
    //    //return false;
    //});



    //$("div#Nhap_Diem_ActionButton").hide();
    //$("div#Xep_Loai_ActionButton").hide();

    //$("select#Nhap_Diem_ListLopHoc").change(function (e) {
    //    e.preventDefault();
    //    var idMonHoc = $("select#Nhap_Diem_ListMonHoc").val();
    //    var idLopHoc = $(this).val();
    //    if (idMonHoc != "" && idLopHoc != "") {
    //        $.ajax({
    //            beforeSend: function (request) {
    //                $.blockUI();
    //            },
    //            complete: function (request, result) {
    //                $.unblockUI();
    //            },
    //            type: "POST",
    //            url: getRootUrl() + '/SoDiem/GetAllHocSinh',
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            data: JSON.stringify({
    //                IdLopHoc: idLopHoc,
    //                IdMonHoc: idMonHoc
    //            }),
    //            async: false,
    //            success: function (result) {
    //                if (result != null && result.length > 0) {
    //                    var htmlRows = '';
    //                    var listHocSinh = result[0];
    //                    var listSoDiem = result[1];
    //                    if (listHocSinh.length > 0) {
    //                        for (var i = 0; i < listHocSinh.length; i++) {

    //                            var sodiemId = "0";
    //                            var TBHK1 = "", TBHK2 = "", hanhKiem = "", hocLuc = "";
    //                            if (listSoDiem != null) {
    //                                for (var k = 0; k < listSoDiem.length; k++) {
    //                                    if (listSoDiem[k].MaHocSinh == listHocSinh[i].Id) {
    //                                        sodiemId = listSoDiem[k].Id;
    //                                        TBHK1 = listSoDiem[k].TBHK1;
    //                                        TBHK2 = listSoDiem[k].TBHK2;
    //                                        hanhKiem = listSoDiem[k].HanhKiem;
    //                                        hocLuc = listSoDiem[k].HocLuc;
    //                                        break;
    //                                    }
    //                                }
    //                            }

    //                            htmlRows += '<tr data-id="' + sodiemId + '" data-hs-id="' + listHocSinh[i].Id + '" data-mh-id="' + idMonHoc + '" data-lh-id="' + idLopHoc + '"  data-hk="' + hanhKiem + '"  data-hl="' + hocLuc + '">';

    //                            htmlRows += '<td>' + listHocSinh[i].SoTT + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].MaHS + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].HoVaTen + '</td>';

    //                            var ngaySinh = new Date(parseInt(listHocSinh[i].NgaySinh.replace(/(^.*\()|([+-].*$)/g, '')));
    //                            htmlRows += '<td>' + $.format.date(ngaySinh, "yyyy-MM-dd") + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].GioiTinh + '</td>';

    //                            htmlRows += '<td><input data-for="TBHK1" autocomplete="off" class="form-control" placeholder="Điểm TB HK1" type="text" value="' + TBHK1 + '" ></td>';
    //                            htmlRows += '<td><input data-for="TBHK2" autocomplete="off" class="form-control" placeholder="Điểm TB HK2" type="text" value="' + TBHK2 + '"></td>';

    //                            htmlRows += '</tr>';
    //                        }

    //                        $("div#Nhap_Diem_ActionButton").show();

    //                    } else {
    //                        htmlRows += '<tr><td colspan="7">Không có bản ghi nào</td></tr>';
    //                        $("div#Nhap_Diem_ActionButton").hide();
    //                    }
    //                    $("tbody#Nhap_Diem_ListHocSinh").empty();
    //                    $("tbody#Nhap_Diem_ListHocSinh").append(htmlRows);
    //                }
    //            },
    //            error: function (xhr, status, p3, p4) {
    //                alert('Có lỗi khi lấy dữ liệu')
    //            }
    //        });
    //    } else {
    //        $("tbody#Nhap_Diem_ListHocSinh").empty();
    //        $("div#Nhap_Diem_ActionButton").hide();
    //    }
    //});

    //$("select#Nhap_Diem_ListMonHoc").change(function (e) {
    //    e.preventDefault();
    //    var idLopHoc = $("select#Nhap_Diem_ListLopHoc").val();
    //    var idMonHoc = $(this).val();
    //    if (idLopHoc != "" && idMonHoc != "") {
    //        $.ajax({
    //            beforeSend: function (request) {
    //                $.blockUI();
    //            },
    //            complete: function (request, result) {
    //                $.unblockUI();
    //            },
    //            type: "POST",
    //            url: getRootUrl() + '/SoDiem/GetAllHocSinh',
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            data: JSON.stringify({
    //                IdLopHoc: idLopHoc,
    //                IdMonHoc: idMonHoc
    //            }),
    //            async: false,
    //            success: function (result) {
    //                if (result != null && result.length > 0) {
    //                    var htmlRows = '';

    //                    var listHocSinh = result[0];
    //                    var listSoDiem = result[1];

    //                    if (listHocSinh.length > 0) {

    //                        for (var i = 0; i < listHocSinh.length; i++) {

    //                            var sodiemId = "0";
    //                            var TBHK1 = "", TBHK2 = "", hanhKiem = "", hocLuc = "";
    //                            if (listSoDiem != null) {
    //                                for (var k = 0; k < listSoDiem.length; k++) {
    //                                    if (listSoDiem[k].MaHocSinh == listHocSinh[i].Id) {
    //                                        sodiemId = listSoDiem[k].Id;
    //                                        TBHK1 = listSoDiem[k].TBHK1;
    //                                        TBHK2 = listSoDiem[k].TBHK2;
    //                                        hanhKiem = listSoDiem[k].HanhKiem;
    //                                        hocLuc = listSoDiem[k].HocLuc;
    //                                        break;
    //                                    }
    //                                }
    //                            }

    //                            htmlRows += '<tr data-id="' + sodiemId + '" data-hs-id="' + listHocSinh[i].Id + '" data-mh-id="' + idMonHoc + '" data-lh-id="' + idLopHoc + '"  data-hk="' + hanhKiem + '"  data-hl="' + hocLuc + '">';

    //                            htmlRows += '<td>' + listHocSinh[i].SoTT + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].MaHS + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].HoVaTen + '</td>';

    //                            var ngaySinh = new Date(parseInt(listHocSinh[i].NgaySinh.replace(/(^.*\()|([+-].*$)/g, '')));
    //                            htmlRows += '<td>' + $.format.date(ngaySinh, "yyyy-MM-dd") + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].GioiTinh + '</td>';

    //                            htmlRows += '<td><input data-for="TBHK1" autocomplete="off" class="form-control" placeholder="Điểm TB HK1" type="text" value="' + TBHK1 + '" ></td>';
    //                            htmlRows += '<td><input data-for="TBHK2" autocomplete="off" class="form-control" placeholder="Điểm TB HK2" type="text" value="' + TBHK2 + '"></td>';

    //                            htmlRows += '</tr>';
    //                        }

    //                        $("div#Nhap_Diem_ActionButton").show();

    //                    } else {
    //                        htmlRows += '<tr><td colspan="7">Không có bản ghi nào</td></tr>';
    //                        $("div#Nhap_Diem_ActionButton").hide();
    //                    }
    //                    $("tbody#Nhap_Diem_ListHocSinh").empty();
    //                    $("tbody#Nhap_Diem_ListHocSinh").append(htmlRows);
    //                }
    //            },
    //            error: function (xhr, status, p3, p4) {
    //                alert('Có lỗi khi lấy dữ liệu')
    //            }
    //        });
    //    } else {
    //        $("tbody#Nhap_Diem_ListHocSinh").empty();
    //        $("div#Nhap_Diem_ActionButton").hide();
    //    }
    //});

    //$('button#Nhap_Diem_Button_Luu').click(function (e) {
    //    var sodiemList = [];
    //    $("tbody#Nhap_Diem_ListHocSinh").children('tr').each(function () {
    //        if ($(this).attr('data-id') != null) {

    //            var sodiemModel = new Object();

    //            var sodiemId = $(this).attr('data-id');
    //            var hocsinhId = $(this).attr('data-hs-id');
    //            var monhocId = $(this).attr('data-mh-id');
    //            var hanhKiem = $(this).attr('data-hk');
    //            var hocLuc = $(this).attr('data-hl');

    //            var TBHK1 = $(this).find('input[type=text]:eq(0)').val();
    //            var TBHK2 = $(this).find('input[type=text]:eq(1)').val();

    //            sodiemModel["Id"] = parseInt(sodiemId);
    //            sodiemModel["MaHocSinh"] = parseInt(hocsinhId);
    //            sodiemModel["MaMonHoc"] = parseInt(monhocId);

    //            if (TBHK1 != "") {
    //                sodiemModel["TBHK1"] = parseFloat(TBHK1);
    //            } else {
    //                sodiemModel["TBHK1"] = 0;
    //            }

    //            if (TBHK2 != "") {
    //                sodiemModel["TBHK2"] = parseFloat(TBHK2);
    //            } else {
    //                sodiemModel["TBHK2"] = 0;
    //            }

    //            var tbCANAM = ((sodiemModel["TBHK2"] * 2) + sodiemModel["TBHK1"]) / 3;
    //            sodiemModel["TBCN"] = tbCANAM;

    //            if (tbCANAM > 8) {
    //                hocLuc = "Giỏi";
    //            } else if (tbCANAM > parseFloat("6.5")) {
    //                hocLuc = "Khá";
    //            } else if (tbCANAM > 5) {
    //                hocLuc = "Trung bình";
    //            } else if (tbCANAM > parseFloat("3.5")) {
    //                hocLuc = "Yếu";
    //            } else {
    //                hocLuc = "Kém";
    //            }

    //            sodiemModel["HocLuc"] = hocLuc;

    //            if (hanhKiem == "null") hanhKiem = "";

    //            sodiemModel["HanhKiem"] = hanhKiem;

    //            sodiemList.push(sodiemModel);
    //        }
    //    });

    //    if (sodiemList.length > 0) {
    //        $.ajax({
    //            beforeSend: function (request) {
    //                $.blockUI();
    //            },
    //            complete: function (request, result) {
    //                $.unblockUI();
    //            },
    //            type: "POST",
    //            url: getRootUrl() + '/SoDiem/UpdateAllHocSinh',
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            data: JSON.stringify({ 'listSoDiem': sodiemList }),
    //            async: false,
    //            success: function (result) {
    //                if (result != null && result.length > 0) {
    //                    var htmlRows = '';

    //                    var listHocSinh = result[0];
    //                    var listSoDiem = result[1];

    //                    var idLopHoc = $("select#Nhap_Diem_ListLopHoc").val();
    //                    var idMonHoc = $("select#Nhap_Diem_ListMonHoc").val();

    //                    if (listHocSinh.length > 0) {

    //                        for (var i = 0; i < listHocSinh.length; i++) {

    //                            var sodiemId = "";
    //                            var TBHK1 = "", TBHK2 = "", hanhKiem = "", hocLuc = "";
    //                            if (listSoDiem != null) {
    //                                for (var k = 0; k < listSoDiem.length; k++) {
    //                                    if (listSoDiem[k].MaHocSinh == listHocSinh[i].Id) {
    //                                        sodiemId = listSoDiem[k].Id;
    //                                        TBHK1 = listSoDiem[k].TBHK1;
    //                                        TBHK2 = listSoDiem[k].TBHK2;
    //                                        hanhKiem = listSoDiem[k].HanhKiem;
    //                                        hocLuc = listSoDiem[k].HocLuc;
    //                                        break;
    //                                    }
    //                                }
    //                            }

    //                            htmlRows += '<tr data-id="' + sodiemId + '" data-hs-id="' + listHocSinh[i].Id + '" data-mh-id="' + idMonHoc + '" data-lh-id="' + idLopHoc + '"  data-hk="' + hanhKiem + '"  data-hl="' + hocLuc + '">';

    //                            htmlRows += '<td>' + listHocSinh[i].SoTT + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].MaHS + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].HoVaTen + '</td>';

    //                            var ngaySinh = new Date(parseInt(listHocSinh[i].NgaySinh.replace(/(^.*\()|([+-].*$)/g, '')));
    //                            htmlRows += '<td>' + $.format.date(ngaySinh, "yyyy-MM-dd") + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].GioiTinh + '</td>';

    //                            htmlRows += '<td><input data-for="TBHK1" autocomplete="off" class="form-control" placeholder="Điểm TB HK1" type="text" value="' + TBHK1 + '" ></td>';
    //                            htmlRows += '<td><input data-for="TBHK2" autocomplete="off" class="form-control" placeholder="Điểm TB HK2" type="text" value="' + TBHK2 + '"></td>';

    //                            htmlRows += '</tr>';
    //                        }

    //                        $("div#Nhap_Diem_ActionButton").show();

    //                    } else {
    //                        htmlRows += '<tr><td colspan="7">Không có bản ghi nào</td></tr>';
    //                        $("div#Nhap_Diem_ActionButton").hide();
    //                    }
    //                    $("tbody#Nhap_Diem_ListHocSinh").empty();
    //                    $("tbody#Nhap_Diem_ListHocSinh").append(htmlRows);
    //                }
    //            },
    //            error: function (xhr, status, p3, p4) {
    //                alert('Có lỗi khi lấy dữ liệu')
    //            }
    //        });
    //    }

    //});

    ////Nút xóa chưa làm gì
    //$('button#Nhap_Diem_Button_Xoa').click(function (e) {
    //    $("tbody#Nhap_Diem_ListHocSinh").children('tr').each(function () {
    //        if ($(this).attr('data-id') != null) {

    //        }
    //    });
    //});

    //$("select#Xep_Loai_ListLopHoc").change(function (e) {
    //    e.preventDefault();
    //    var idMonHoc = $("select#Xep_Loai_ListMonHoc").val();
    //    var idLopHoc = $(this).val();
    //    if (idMonHoc != "" && idLopHoc != "") {
    //        $.ajax({
    //            beforeSend: function (request) {
    //                $.blockUI();
    //            },
    //            complete: function (request, result) {
    //                $.unblockUI();
    //            },
    //            type: "POST",
    //            url: getRootUrl() + '/SoDiem/GetAllHocSinh',
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            data: JSON.stringify({
    //                IdLopHoc: idLopHoc,
    //                IdMonHoc: idMonHoc
    //            }),
    //            async: false,
    //            success: function (result) {
    //                if (result != null && result.length > 0) {
    //                    var htmlRows = '';
    //                    var listHocSinh = result[0];
    //                    var listSoDiem = result[1];
    //                    if (listHocSinh.length > 0) {
    //                        for (var i = 0; i < listHocSinh.length; i++) {

    //                            var sodiemId = "0";
    //                            var TBHK1 = "", TBHK2 = "", TBCN = "", hanhKiem = "", hocLuc = "";
    //                            if (listSoDiem != null) {
    //                                for (var k = 0; k < listSoDiem.length; k++) {
    //                                    if (listSoDiem[k].MaHocSinh == listHocSinh[i].Id) {
    //                                        sodiemId = listSoDiem[k].Id;
    //                                        TBHK1 = listSoDiem[k].TBHK1;
    //                                        TBHK2 = listSoDiem[k].TBHK2;
    //                                        TBCN = listSoDiem[k].TBCN;
    //                                        hanhKiem = listSoDiem[k].HanhKiem;
    //                                        hocLuc = listSoDiem[k].HocLuc;
    //                                        break;
    //                                    }
    //                                }
    //                            }

    //                            htmlRows += '<tr data-id="' + sodiemId + '" data-hs-id="' + listHocSinh[i].Id + '" data-mh-id="' + idMonHoc + '" data-lh-id="' + idLopHoc + '"  data-hk="' + hanhKiem + '" data-hl="' + hocLuc + '" data-tbhk1="' + TBHK1 + '" data-tbhk2="' + TBHK2 + '" data-tbcn="' + TBCN + '">';

    //                            htmlRows += '<td>' + listHocSinh[i].SoTT + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].MaHS + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].HoVaTen + '</td>';

    //                            var ngaySinh = new Date(parseInt(listHocSinh[i].NgaySinh.replace(/(^.*\()|([+-].*$)/g, '')));
    //                            htmlRows += '<td>' + $.format.date(ngaySinh, "yyyy-MM-dd") + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].GioiTinh + '</td>';

    //                            htmlRows += '<td>' + TBHK1 + '</td>';
    //                            htmlRows += '<td>' + TBHK2 + '</td>';
    //                            htmlRows += '<td>' + TBCN + '</td>';

    //                            htmlRows += '<td>' + hocLuc + '</td>';
    //                            htmlRows += '<td><input data-for="HanhKiem" autocomplete="off" class="form-control" placeholder="Hạnh kiểm" type="text" value="' + hanhKiem + '"></td>';

    //                            htmlRows += '</tr>';
    //                        }

    //                        $("div#Xep_Loai_ActionButton").show();

    //                    } else {
    //                        htmlRows += '<tr><td colspan="7">Không có bản ghi nào</td></tr>';
    //                        $("div#Xep_Loai_ActionButton").hide();
    //                    }
    //                    $("tbody#Xep_Loai_ListHocSinh").empty();
    //                    $("tbody#Xep_Loai_ListHocSinh").append(htmlRows);
    //                }
    //            },
    //            error: function (xhr, status, p3, p4) {
    //                alert('Có lỗi khi lấy dữ liệu')
    //            }
    //        });
    //    } else {
    //        $("tbody#Xep_Loai_ListHocSinh").empty();
    //        $("div#Xep_Loai_ActionButton").hide();
    //    }
    //});

    //$("select#Xep_Loai_ListMonHoc").change(function (e) {
    //    e.preventDefault();
    //    var idLopHoc = $("select#Xep_Loai_ListLopHoc").val();
    //    var idMonHoc = $(this).val();
    //    if (idLopHoc != "" && idMonHoc != "") {
    //        $.ajax({
    //            beforeSend: function (request) {
    //                $.blockUI();
    //            },
    //            complete: function (request, result) {
    //                $.unblockUI();
    //            },
    //            type: "POST",
    //            url: getRootUrl() + '/SoDiem/GetAllHocSinh',
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            data: JSON.stringify({
    //                IdLopHoc: idLopHoc,
    //                IdMonHoc: idMonHoc
    //            }),
    //            async: false,
    //            success: function (result) {
    //                if (result != null && result.length > 0) {
    //                    var htmlRows = '';

    //                    var listHocSinh = result[0];
    //                    var listSoDiem = result[1];

    //                    if (listHocSinh.length > 0) {

    //                        for (var i = 0; i < listHocSinh.length; i++) {

    //                            var sodiemId = "0";
    //                            var TBHK1 = "", TBHK2 = "", TBCN = "", hanhKiem = "", hocLuc = "";
    //                            if (listSoDiem != null) {
    //                                for (var k = 0; k < listSoDiem.length; k++) {
    //                                    if (listSoDiem[k].MaHocSinh == listHocSinh[i].Id) {
    //                                        sodiemId = listSoDiem[k].Id;
    //                                        TBHK1 = listSoDiem[k].TBHK1;
    //                                        TBHK2 = listSoDiem[k].TBHK2;
    //                                        TBCN = listSoDiem[k].TBCN;
    //                                        hanhKiem = listSoDiem[k].HanhKiem;
    //                                        hocLuc = listSoDiem[k].HocLuc;
    //                                        break;
    //                                    }
    //                                }
    //                            }

    //                            htmlRows += '<tr data-id="' + sodiemId + '" data-hs-id="' + listHocSinh[i].Id + '" data-mh-id="' + idMonHoc + '" data-lh-id="' + idLopHoc + '"  data-hk="' + hanhKiem + '" data-hl="' + hocLuc + '" data-tbhk1="' + TBHK1 + '" data-tbhk2="' + TBHK2 + '" data-tbcn="' + TBCN + '">';

    //                            htmlRows += '<td>' + listHocSinh[i].SoTT + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].MaHS + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].HoVaTen + '</td>';

    //                            var ngaySinh = new Date(parseInt(listHocSinh[i].NgaySinh.replace(/(^.*\()|([+-].*$)/g, '')));
    //                            htmlRows += '<td>' + $.format.date(ngaySinh, "yyyy-MM-dd") + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].GioiTinh + '</td>';

    //                            htmlRows += '<td>' + TBHK1 + '</td>';
    //                            htmlRows += '<td>' + TBHK2 + '</td>';
    //                            htmlRows += '<td>' + TBCN + '</td>';

    //                            htmlRows += '<td>' + hocLuc + '</td>';
    //                            htmlRows += '<td><input data-for="HanhKiem" autocomplete="off" class="form-control" placeholder="Hạnh kiểm" type="text" value="' + hanhKiem + '"></td>';

    //                            htmlRows += '</tr>';
    //                        }

    //                        $("div#Xep_Loai_ActionButton").show();

    //                    } else {
    //                        htmlRows += '<tr><td colspan="7">Không có bản ghi nào</td></tr>';
    //                        $("div#Xep_Loai_ActionButton").hide();
    //                    }
    //                    $("tbody#Xep_Loai_ListHocSinh").empty();
    //                    $("tbody#Xep_Loai_ListHocSinh").append(htmlRows);
    //                }
    //            },
    //            error: function (xhr, status, p3, p4) {
    //                alert('Có lỗi khi lấy dữ liệu')
    //            }
    //        });
    //    } else {
    //        $("tbody#Xep_Loai_ListHocSinh").empty();
    //        $("div#Xep_Loai_ActionButton").hide();
    //    }
    //});

    //$('button#Xep_Loai_Button_Luu').click(function (e) {
    //    var sodiemList = [];
    //    $("tbody#Xep_Loai_ListHocSinh").children('tr').each(function () {
    //        if ($(this).attr('data-id') != null) {

    //            var sodiemModel = new Object();

    //            var sodiemId = $(this).attr('data-id');
    //            var hocsinhId = $(this).attr('data-hs-id');
    //            var monhocId = $(this).attr('data-mh-id');
    //            var hocLuc = $(this).attr('data-hl');

    //            var TBHK1 = $(this).attr('data-tbhk1');
    //            var TBHK2 = $(this).attr('data-tbhk2');
    //            var TBCN = $(this).attr('data-tbcn');

    //            var hanhKiem = $(this).find('input[type=text]:eq(0)').val();

    //            sodiemModel["Id"] = parseInt(sodiemId);
    //            sodiemModel["MaHocSinh"] = parseInt(hocsinhId);
    //            sodiemModel["MaMonHoc"] = parseInt(monhocId);

    //            if (TBHK1 != "") {
    //                sodiemModel["TBHK1"] = parseFloat(TBHK1);
    //            } else {
    //                sodiemModel["TBHK1"] = 0;
    //            }

    //            if (TBHK2 != "") {
    //                sodiemModel["TBHK2"] = parseFloat(TBHK2);
    //            } else {
    //                sodiemModel["TBHK2"] = 0;
    //            }

    //            if (TBCN != "") {
    //                sodiemModel["TBCN"] = parseFloat(TBCN);
    //            } else {
    //                sodiemModel["TBCN"] = 0;
    //            }

    //            sodiemModel["HocLuc"] = hocLuc;

    //            sodiemModel["HanhKiem"] = hanhKiem;

    //            sodiemList.push(sodiemModel);
    //        }
    //    });

    //    if (sodiemList.length > 0) {
    //        $.ajax({
    //            beforeSend: function (request) {
    //                $.blockUI();
    //            },
    //            complete: function (request, result) {
    //                $.unblockUI();
    //            },
    //            type: "POST",
    //            url: getRootUrl() + '/SoDiem/UpdateAllHocSinh',
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            data: JSON.stringify({ 'listSoDiem': sodiemList }),
    //            async: false,
    //            success: function (result) {
    //                if (result != null && result.length > 0) {
    //                    var htmlRows = '';

    //                    var listHocSinh = result[0];
    //                    var listSoDiem = result[1];

    //                    var idLopHoc = $("select#Nhap_Diem_ListLopHoc").val();
    //                    var idMonHoc = $("select#Nhap_Diem_ListMonHoc").val();

    //                    if (listHocSinh.length > 0) {

    //                        for (var i = 0; i < listHocSinh.length; i++) {

    //                            var sodiemId = "0";
    //                            var TBHK1 = "", TBHK2 = "", TBCN = "", hanhKiem = "", hocLuc = "";
    //                            if (listSoDiem != null) {
    //                                for (var k = 0; k < listSoDiem.length; k++) {
    //                                    if (listSoDiem[k].MaHocSinh == listHocSinh[i].Id) {
    //                                        sodiemId = listSoDiem[k].Id;
    //                                        TBHK1 = listSoDiem[k].TBHK1;
    //                                        TBHK2 = listSoDiem[k].TBHK2;
    //                                        TBCN = listSoDiem[k].TBCN;
    //                                        hanhKiem = listSoDiem[k].HanhKiem;
    //                                        hocLuc = listSoDiem[k].HocLuc;
    //                                        break;
    //                                    }
    //                                }
    //                            }

    //                            htmlRows += '<tr data-id="' + sodiemId + '" data-hs-id="' + listHocSinh[i].Id + '" data-mh-id="' + idMonHoc + '" data-lh-id="' + idLopHoc + '"  data-hk="' + hanhKiem + '" data-hl="' + hocLuc + '" data-tbhk1="' + TBHK1 + '" data-tbhk2="' + TBHK2 + '" data-tbcn="' + TBCN + '">';

    //                            htmlRows += '<td>' + listHocSinh[i].SoTT + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].MaHS + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].HoVaTen + '</td>';

    //                            var ngaySinh = new Date(parseInt(listHocSinh[i].NgaySinh.replace(/(^.*\()|([+-].*$)/g, '')));
    //                            htmlRows += '<td>' + $.format.date(ngaySinh, "yyyy-MM-dd") + '</td>';
    //                            htmlRows += '<td>' + listHocSinh[i].GioiTinh + '</td>';

    //                            htmlRows += '<td>' + TBHK1 + '</td>';
    //                            htmlRows += '<td>' + TBHK2 + '</td>';
    //                            htmlRows += '<td>' + TBCN + '</td>';

    //                            htmlRows += '<td>' + hocLuc + '</td>';
    //                            htmlRows += '<td><input data-for="HanhKiem" autocomplete="off" class="form-control" placeholder="Hạnh kiểm" type="text" value="' + hanhKiem + '"></td>';

    //                            htmlRows += '</tr>';
    //                        }

    //                        $("div#Xep_Loai_ActionButton").show();

    //                    } else {
    //                        htmlRows += '<tr><td colspan="7">Không có bản ghi nào</td></tr>';
    //                        $("div#Xep_Loai_ActionButton").hide();
    //                    }
    //                    $("tbody#Xep_Loai_ListHocSinh").empty();
    //                    $("tbody#Xep_Loai_ListHocSinh").append(htmlRows);
    //                }
    //            },
    //            error: function (xhr, status, p3, p4) {
    //                alert('Có lỗi khi lấy dữ liệu')
    //            }
    //        });
    //    }

    //});

    ////Nút xóa chưa làm gì
    //$('button#Xep_Loai_Button_Xoa').click(function (e) {
    //    $("tbody#Xep_Loai_ListHocSinh").children('tr').each(function () {
    //        if ($(this).attr('data-id') != null) {

    //        }
    //    });
    //});

    //$("select#Home_ListLopHoc").change(function (e) {
    //    window.location.href = getRootUrl() + '/Home/LopHoc?id=' + $(this).val();
    //});

});