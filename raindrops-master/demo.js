window.onload = function() {
    $('#demo').height($(window).height());
    jQuery('#demo').raindrops({
        canvasHeight: $(window).height(),
        waveLength: 100,
        rippleSpeed: 0.05
    });
}