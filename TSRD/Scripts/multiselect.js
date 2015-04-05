
    $('.list-span').click(function () {
        if (confirm("確認刪除?"))
            $(this).remove()
        else
            return false
    })


    $('.list-btn-multiselect').each(function (index) {
        $(this).click(function () {
            var selectName = $(this).parent().parent().children('span').first().html();
            var appendNew = true;
            var listContainer = $(this).parent().parent().children('span').first().next();
            //$('#list' + selectName);
            var selectContainer = $(this).parent().children('select').first();
            //$('#select' + selectName);               
            listContainer.children('span').children('input').each(function (index) {
                if ($(this).val() == selectContainer.children('option:selected').val()) {
                    appendNew = false;
                }
            });
            if (appendNew) {
                listContainer.append(
                    $('<span></span>').html(selectContainer.children('option:selected').html())
                        .addClass('btn btn-info list-span')
                        .click(function () {
                            if (confirm("確認刪除?"))
                                $(this).remove()
                            else
                                return false
                        })
                        .append(
                        $('<input></input>')
                            .attr('type', 'hidden')
                            .attr('name', selectName + '[]')
                            .val(selectContainer.val())
                    )
                );
            }
            return false;
        })
        
    });
        
                
          