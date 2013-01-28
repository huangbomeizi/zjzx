$(document).ready(function(){
    $('#mytable tr:even').addClass('libg');
    $("#mytable tr").mouseover(function(){
	    $(this).addClass('hover');
    });
    $('#mytable tr').mouseout(function(){
	    $(this).removeClass('hover');
    });
});
function checkAll(id) {
	if (id.checked) {
		$("input[name='checkRow']").attr("checked", true);
	} else {
		$("input[name='checkRow']").attr("checked", false);
	}
}