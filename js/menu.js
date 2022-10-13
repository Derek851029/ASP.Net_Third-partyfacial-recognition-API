function menuBuilder($menu, dataArray) {
    this.dataArray = dataArray;
    this.$menu = $menu;
    //$(data.d).filter((index,item)=> item.PARENT_ID==0).map((index,p)=>p);
}

menuBuilder.prototype = {
    createMenuItem: function (itemData, isRootLi) {
        if (isRootLi === undefined) {
            isRootLi = false;
        }
        var that = this;
        var subList = this.findSubMenu(itemData.TREE_ID);
        var link = null;
        var item = null;
        if (subList.length > 0) {

            link = $('<a>', {
                href: "#",
                //html: itemData.TREE_NAME,
                "id": itemData.TREE_ID,
                "class": "dropdown-toggle",
                "data-toggle": "dropdown",
                "style": "color:#FF8800;",
                //"aria-haspopup": "true",
                //"role": "button",
                //"aria-expanded": "false"
            })
                .append($('<span>', { class: "glyphicon glyphicon-" + itemData.IMAGE_FILE }))
                .append(itemData.TREE_NAME)
            if (isRootLi) {
                link.append($("<span>", { class: "caret" }));
            }
            //更改menu bar
            item = $('<li>', { class: isRootLi ? "" : "dropdown-submenu" })
                .append(link);
            var _subList = $('<ul>', {
                "class": "dropdown-menu",
                "style": "font-size:22px",
                //"role": "menu",
                //"aria-labelledby": itemData.TREE_ID
            });
            $.each(subList, function () {
                _subList.append(
                    that.createMenuItem(this)
                );
            });
            item.append(_subList);
        } else {
            //<a role="menuitem" href="../0101010001.aspx">新契約報備連結</a>
            link = $('<a>', {
                //"style": "font-size:20px",
                //"role": "menuitem",
                href: itemData.NAVIGATE_URL
            })
                .append(itemData.TREE_NAME);
            item = $('<li>', { role: "presentation"})
                .append(link);
        }
        return item;
    },
    findSubMenu: function (parentId) {
        return $(this.dataArray)
            .filter(function (index, item) { return item.PARENT_ID == parentId; })
            .map(function (index, p) { return p; })
            .get();
    },
    createMenu: function () {
        var list = this.findSubMenu(0);
        var that = this;
        $.each(list, function () {
            that.$menu.append(
                that.createMenuItem(this, true)
            );
        });
    }
}

$(function () {
    $.ajax({
        url: 'Menu.aspx/getMenu',
        type: 'POST',
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
    }).done(function (data) {
        console.log(data.d);
        var builder = new menuBuilder($("#menu"), data.d);
        builder.createMenu();
    });

});