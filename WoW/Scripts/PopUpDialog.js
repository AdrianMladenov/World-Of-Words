$(document).ready(function () {
    let url = "";

    $("#dialog-edit").dialog({
        title: 'Промени дума',
        autoOpen: false,
        resizable: false,
        width: 400,
        height: 350,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        fluid: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
            $('#dialog-edit').css('overflow', 'hidden');
        }
    });

    $("#dialog-confirm").dialog({
        title: 'Изтрий дума',
        autoOpen: false,
        resizable: false,
        height: 170,
        width: 350,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
        }
    });

    $(".lnkEdit").on("click", function (e) {
        // e.preventDefault(); use this or return false
        url = $(this).attr('href');
        
        $("#dialog-edit").dialog('open');

        return false;
    });

    $(".lnkDelete").on("click", function (e) {
        // e.preventDefault(); use this or return false
        url = $(this).attr('href');
        $("#dialog-confirm").dialog('open');

        return false;
    });
});