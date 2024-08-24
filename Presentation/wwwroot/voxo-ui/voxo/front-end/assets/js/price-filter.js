// Trigger

$(function () {
    var viewBagMax = parseFloat(document.getElementById("jsValueMax").value);
    var viewBagMin = parseFloat(document.getElementById("jsValueMin").value);
    var viewBagMaxPriceLimit = parseFloat(document.getElementById("jsMaxPriceLimit").value);

  var $range = $(".js-range-slider"),
    $inputFrom = $(".js-input-from"),
    $inputTo = $(".js-input-to"),
    instance,
    min = 0,
    max = viewBagMaxPriceLimit,
    from = viewBagMin,
    to = viewBagMax;

  $range.ionRangeSlider({
    type: "double",
    min: min,
    max: max,
    from: from,
    to: to,
     postfix : " ₼",
    onStart: updateInputs,
    onChange: updateInputs,
    step: 1,
    prettify_enabled: true,
    prettify_separator: ".",
    values_separator: " - ",
    force_edges: true,
  });

  instance = $range.data("ionRangeSlider");

  function updateInputs(data) {
    from = data.from;
    to = data.to;

    $inputFrom.prop("value", from+" ");
    $inputTo.prop("value",  to+" ");

    document.getElementById("minPriceInput").value = from;
    document.getElementById("maxPriceInput").value = to;
  }

    $inputFrom.on("input", function () {
        var val = $(this).prop("value");

        // validate
        if (val < min) {
            val = min;
        } else if (val > to) {
            val = to;
        }

        instance.update({
            from: val,
        });
    });

    $inputTo.on("input", function () {
        var val = $(this).prop("value");

        // validate
        if (val < from) {
            val = from;
        } else if (val > max) {
            val = max;
        }

        instance.update({
            to: val,
        });
    });
});