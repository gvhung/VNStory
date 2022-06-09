
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

    //Khai báo các tùy chọn cho khung editor
    var optionsEditor = {
        display: 'block',
        width: '100%',
        height: 'auto',
        minHeight: '150px',
        maxHeight: '450px',
        popupDisplay: 'full',
        charCounter: true,
        charCounterLabel: 'Characters :',
        buttonList: [
            ['undo', 'redo'],
            ['font', 'fontSize', 'formatBlock'],
            ['paragraphStyle', 'blockquote'],
            ['bold', 'underline', 'italic', 'strike', 'subscript', 'superscript'],
            ['fontColor', 'hiliteColor', 'textStyle'],
            ['removeFormat'],
            ['outdent', 'indent'],
            ['align', 'horizontalRule', 'list', 'lineHeight'],
            ['table', 'link', 'image', 'video', 'audio'],
            ['fullScreen', 'showBlocks', 'codeView'],
            ['preview', 'print'],
            ['save', 'template'],
        ],
        placeholder: 'Start typing something...',
        templates: [
            {
                name: 'Template-1',
                html: '<p>HTML source1</p>'
            },
            {
                name: 'Template-2',
                html: '<p>HTML source2</p>'
            }
        ]
    }

    if ($('#Content').length)
    {
        //Khai báo khung editor có id=Content
        SUNEDITOR.create('Content', optionsEditor);
    }
    
    if ($('#Biography').length)
    {
        SUNEDITOR.create('Biography', optionsEditor);
    }
    

});