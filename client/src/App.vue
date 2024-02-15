<template>
  <header>
    <Navbar />
  </header>
  <main class="container-fluid">
    <section class="row">
      <div class="col-md-2">
        <div class="sticky-top">
          <h1 class="fw-bold text-success text-center">HELP</h1>
          <button v-if="account.id" class="btn btn-success w-100 rounded-0 fw-bold text-light" data-bs-toggle="modal" data-bs-target="#create-report">Report</button>
        </div>
      </div>
      <div class="col">
        <router-view />
      </div>
    </section>
  </main>
   <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
  <ModalWrapper modalId="create-report">
    Modal for my form
    <CreateReportForm/>
  </ModalWrapper>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import ModalWrapper from './components/ModalWrapper.vue'
import CreateReportForm from './components/CreateReportForm.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState),
      account: computed(()=> AppState.account)
    }
  },
  components: { Navbar, ModalWrapper, CreateReportForm }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
