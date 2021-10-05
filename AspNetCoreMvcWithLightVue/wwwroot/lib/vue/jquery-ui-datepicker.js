const jqueryUiDatePicker = {
    template: `<input v-bind:id="id" v-model="selectDate" />`,

    props: {
        id : String,
        modelValue: String,
    },

    setup(props, { emit }){

        let datePickerDom = null;

        onMounted(() => {
            datePickerDom = $( "#" + props.id );

            datePickerDom.datepicker({
                dateFormat : "yy/mm/dd",
                onSelect: function (dateText, inst) {
                    selectDate.value = dateText;
                }
            });
        })

        const selectDate = computed({
            get : () => props.modelValue,
            set : (v) => emit('update:modelValue', v),
        });

        return {
            datePickerDom,
            selectDate
        }
    },
};
