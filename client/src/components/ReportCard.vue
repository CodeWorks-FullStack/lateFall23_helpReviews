<template>
  <div class="card mb-2">
    <!-- REPORT CARD -->
    <div class="card-body">
      <div class="fw-bold text-success text-center">
        "{{ report.title }}"
      </div>
      <p>{{ report.body }}</p>
      <div class="d-flex justify-content-end align-items-baseline">
        <span class="fw-bold me-2">{{ report.creator.name }}</span>
        <img class="report-img" :src="report.creator.picture" :alt="`picture of ${report.creator.name}`">
      </div>
    </div>
  </div>
</template>


<script>
import { Report } from '../models/Report.js';

export default {
  props: {report : {type: Report, required: true}},
setup(){
return{}
}
}
</script>


<style lang="scss" scoped>
.report-img{
  height: 75px;
  width: 75px;
  border-radius: 50em;
}
</style>
