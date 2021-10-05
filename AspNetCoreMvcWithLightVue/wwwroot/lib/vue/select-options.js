const selectOptions = {
    template: `
        <div class="form-group">
            <select class="custom-select"
                    v-bind:id="id"
                    v-bind:disabled="IsDisabled()"
                    v-model="selectedValue">
                <option v-for="option in options"
                        v-bind:value="option.Value">
                    {{ option.Text }}
                </option>
            </select>
        </div>
    `,

    props: {
        id: String,
        modelValue: String,
        options: Array,
        disabled: Boolean,
    },
    setup( props, {
        emit
    } ) {

        const selectedValue = computed({
            get : () => props.modelValue,
            set : (v) => emit('update:modelValue', v),
        });

        function IsDisabled() {
            return props.disabled;
        }

        return {
            selectedValue,
            IsDisabled,
        }
    },
}
