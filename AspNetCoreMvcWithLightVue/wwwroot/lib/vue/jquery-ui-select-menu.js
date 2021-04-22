﻿const jqueryUiSelectMenu = {
    props: {
        page_info: null,
    },
    setup(props, {
        emit
    }) {

        onMounted(() => {
            selectMenuDom = $("#select-menu");
            selectMenuDom.selectmenu({
                width: 100,
                select: function (event, ui) {
                    emit('select-value', ui.item.value)
                }
            });
        })

        let selectMenuDom = null;

        return {
            selectMenuDom,
        }
    },
    template: `
                <select id="select-menu"
                        v-model="page_info.PageNo">
                  <option v-for="pageNo in page_info.PageCount"
                          v-bind:value="pageNo" >
                    {{ pageNo }}
                  </option>
                </select>
    `,
}
