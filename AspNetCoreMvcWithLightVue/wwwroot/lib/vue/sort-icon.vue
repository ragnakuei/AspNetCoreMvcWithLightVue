<template>
    <i v-bind:class="classObject"></i>
</template>

<script>
module.exports = {
    props: {
        page_info: null,
        target_column: null,
    },
    computed: {
        classObject() {

            if (this.page_info.SortColumn === this.target_column) {
                if (this.page_info.SortColumnOrder === 1) {
                    return {
                        'bi bi-sort-up': true,
                    }
                }

                if (this.page_info.SortColumnOrder === 0) {
                    return {
                        'bi bi-sort-down-alt': true,
                    }
                }
            }

            return {}
        }
    }
}
</script>
