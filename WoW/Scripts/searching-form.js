let last_id = 1;
$('select')
  .change(function () {
      $('#letters').empty();
      //let str = '<input type="text" class="form-control" id="letter' + i + '" maxlength="1" autocomplete="off"><span class="spancount">' + i + '</span>';
      let selectedWordLength = $('select option:selected').val();
      for (let i = 1; i <= selectedWordLength; i++) {
          $('#letters').append('<input type="text" class="lett lett-unknown" id="letter' + i + '" maxlength="1" autocomplete="off" ><span class="spancount">' + i + '</span>');
      }
      $('.lett').keydown(input_keydown);
      $('.lett').keyup(input_keyup);
  }).trigger('change');



function set_letter(letter) {
    if (letter != ' ') {
        $('#letter' + last_id).replaceWith('<input type="text" class="lett lett-known" id="letter' + last_id + '" maxlength="1" autocomplete="off"/>');

        let next_id = 1 + parseInt(last_id);
        if ($('#letter' + next_id).length) {
            $('#letter' + next_id).focus();
        }

    } else {
        $('#letter' + last_id).replaceWith('<input type="text" class="lett lett-unknown" id="letter' + last_id + '" value="" maxlength="1" autocomplete="off"/>');
    }


    $('#letter' + last_id).keydown(input_keydown);
    $('#letter' + last_id).keyup(input_keyup);
}



function input_keydown(e) {

    let id = $(this).attr('id');
    last_id = id.replace('letter', '');

    // $('#letter' + last_id).val('');

    let keycode = e.keyCode;

    if ((keycode == 9) || (keycode == 39)) { // tab or right arrow 
        let next_id = 1 + parseInt(last_id);
        if ($('#letter' + next_id).length) {
            $('#letter' + next_id).focus();
        }
        else {
            $('#letter1').focus();
        }
        e.preventDefault();
    }
    else if (keycode == 37) { // left arrow
        let next_id = parseInt(last_id) - 1;
        if (next_id >= 1) {
            if ($('#letter' + next_id).length) {
                $('#letter' + next_id).focus();
            }
            else {
                $('#letter1').focus();
            }
        }
        else {
            $('#letter' + $('select option:selected').val()).focus();
        }
    }
    else if ((keycode == 8) || (keycode == 46)) { // backspase or del
        e.preventDefault();
        let next_id = parseInt(last_id);
        if ($('#letter' + next_id).length) {
            $('#letter' + next_id).focus();
        }
    }
    else {
        let result = ((keycode >= 62) && (keycode <= 90));
        if (!result) {
            e.preventDefault();
        }
        else {
            $(this).addClass('lett-known').removeClass('lett-unknown');

        }
    }

}

function input_keyup(e) {
    let keycode = e.keyCode;
    if (keycode == 27) { // ESCAPE
        set_letter(' ');
        e.preventDefault();
    }
    else if (keycode == 37) { // left arrow
        let next_id = parseInt(last_id) - 1;
        if (next_id > 1) {
            if ($('#letter' + next_id).length) {
                $('#letter' + next_id).focus();
            }
            else {
                $('#letter' + $('select option:selected').val()).focus();
            }
        }
    }
    else if ((keycode == 8) || (keycode == 46)) { // backspase or del
        e.preventDefault();
        set_letter(' ');
        let next_id = parseInt(last_id);
        if ($('#letter' + next_id).length) {
            $('#letter' + next_id).focus();
        }
    }
    else {

        if ($('#letter' + last_id).val() != ' ') {
            let next_id = 1 + parseInt(last_id);
            if ($('#letter' + next_id).length) {
                $('#letter' + next_id).focus();
            } else {
                $('#letter1').focus();
            }
        }
    }
}