$(document).on({
            ajaxStart: () => $('#loadingBox').show(),
            ajaxStop: () => {
                $('#loadingBox').hide()
            }
        })