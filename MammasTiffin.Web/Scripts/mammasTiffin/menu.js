$(function () {
    //Global variable declaration
    var $menuItem = $('.menu-item');
    //Method to check a particular radio button out of radio button list
    var radioButtonSelector = function (radioBtnVal) {
        $("input[name=MenuType][value='" + radioBtnVal + "']").attr("Checked", true);
    }
    //Page load method declaration
    var pageLoad = function () {
        //$('.divOrderNowBtnContainer').hide();
        //$('.divtotalAmountContainer').hide();
        radioButtonSelector("None");
    }
    //Invoke Page load method
    pageLoad();
    //Filter menu by showing and hiding particular menu
    var showHideMenu = function (value) {
        $menuItem.each(function () {
            var $menuItem = $(this);
            if (value === "None") {
                $menuItem.show();
            }
            else if (value === "Veg") {
                if ($menuItem.find('.hdnIsVeg').val() === "Y") {
                    $menuItem.show();
                }
                else {
                    $menuItem.hide();
                }
            }
            else if (value === "NonVeg") {
                if ($menuItem.find('.hdnIsVeg').val() === "N") {
                    $menuItem.show();
                }
                else {
                    $menuItem.hide();
                }
            }
        });
    }
    //Attach change event of radio button list
    $('input[name=MenuType]').change(function () {
        showHideMenu($(this).val());
    });
    //Toggle Add and Qty Buttons
    var toggleAddAndQtyButtons = function (classSelector) {
        var $selector = $('.' + classSelector);
        $selector.find('.spanQty').toggle();
        $selector.find('.btnAddQty').toggle();
    }
    //Hide Show Total and Order Now! button
    var hideShowTotalAndOrderBtn = function () {
        var $divOrderBtn = $('.divOrderNowBtnContainer');
        var $divTotalAmount = $('.divtotalAmountContainer');
        var totalAmount = 0;

        $('.orderContainer .order-item .amount').each(function () {
            var divAmount = this;
            var amount = +$(divAmount).text().split('.')[1];
            totalAmount = totalAmount + amount;
        });

        if ($('.orderContainer .row').length > 0) {
            $divOrderBtn.show();
            $divTotalAmount.show().find('.divtotalAmountColumn').text('Rs.'+totalAmount);
            $('.divEmptyCart').hide();
        }
        else {
            $divOrderBtn.hide();
            $divTotalAmount.hide();
            $('.divEmptyCart').show();
        }

    }
    //Method to update count of a particular menu item ordered
    var updateQtyOfItem = function (selector, isDecButton) {
        var $selector = $("." + selector);//Should be maximum two at any point of time 
        var $qtyInputSelector = $selector.find('.inpTextQty');
        var currentQty = +$qtyInputSelector.val();

        if (isDecButton) {
            if (currentQty <= 1) {
                toggleAddAndQtyButtons(selector);
                $('.orderContainer').find("." + selector).remove();
            }
            else {
                $qtyInputSelector.val(currentQty - 1);
            }
        }
        else {
            $qtyInputSelector.val(currentQty + 1);
        }
        var price = +$selector.find('.price').text().split('.')[1];
        var updatedQty = +$qtyInputSelector.val();
        $selector.find('.amount').text('Rs.' + (price * updatedQty));
        hideShowTotalAndOrderBtn();
    }

    //Add button click event handler
    $('.menuWrapper').on('click', '.btnAddQty', function () {
        var addBtnClick = this;
        var $qtyWrapper = $(addBtnClick).parent();
        $qtyWrapper.find('.inpTextQty').val(0);
        $qtyWrapper.find('.btninc').trigger('click');
        $qtyWrapper.find('.spanQty').show();
        $qtyWrapper.find('.btnAddQty').hide();
    });
    //Qty increase button click event handler
    $('.menuWrapper').on('click', '.btninc', function () {
        var incBtnClick = this;
        var menuItemclass = $(incBtnClick).parents('.menu-item,.order-item').attr('class').split(' ')[2];
        updateItemsToOrderSection(menuItemclass);
        updateQtyOfItem(menuItemclass, false);
    });
    //Qty decrease button click event handler
    $('.menuWrapper').on('click', '.btndec', function () {
        var decBtnClick = this;
        var menuItemclass = $(decBtnClick).parents('.menu-item,.order-item').attr('class').split(' ')[2];
        updateItemsToOrderSection(menuItemclass);
        updateQtyOfItem(menuItemclass, true);
    });
    //
    var updateItemsToOrderSection = function (menuItemClass) {
        var $menuItemContainer = $('.' + menuItemClass);
        var $orderDetailsContainer = $('.orderContainer');

        if ($orderDetailsContainer.find('.' + menuItemClass).length === 0) {
            var itemNameWithIcon = $menuItemContainer.find('.itemNameWithIcon').html();
            var qtyButtons = $menuItemContainer.find('.spanQty').html();
            var price = $menuItemContainer.find('.price').text();
            var consolidatedHtmlString = "<div class='row order-item " + menuItemClass + "'>" +
                "<div class='row'>" + itemNameWithIcon + "</div>" +
                "<div class='row'><div class='col-xs-4'>" + qtyButtons + "</div>" +
                "<div class='col-xs-2'>" + " X " + "</div>" +
                "<div class='col-xs-3'>" + price + "</div>" +
                "<div class='col-xs-3 amount'></div></div>" +
                "</div>";
            $orderDetailsContainer.append(consolidatedHtmlString);
        }
    }
});