<template>
  <div
    class="modal fade"
    :id="modalId"
    tabindex="-1"
    data-bs-backdrop="static"
    data-bs-keyboard="false"

    role="dialog"
    aria-labelledby="modalTitleId"
    aria-hidden="true"
  >
    <div
      class="modal-dialog modal-dialog-scrollable modal-dialog-centered"
      role="document"
    >
      <div class="modal-content">
        <div class="modal-body">
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
          <slot>

          </slot>
        </div>
      </div>
    </div>
  </div>

</template>


<script>
export default {
  props: {modalId: {type: String, required: true}},
setup(){
return{}
}
}
</script>


<style lang="scss" scoped>

</style>
