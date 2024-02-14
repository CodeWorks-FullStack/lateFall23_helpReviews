<template>
  <RouterLink :to="{name: 'Restaurant Details Page', params: {restaurantId: restaurant.id}}" class="card selectable text-success">
    <img :src="restaurant.coverImg" class="card-img" alt="">
    <div class="card-body">
      <p class="fw-bold text-success">🍝{{ restaurant.name }}</p>
      <p class="text-dark">{{ restaurant.description }}</p>
      <div class="d-flex justify-content-between text-center">
        <div>
          <i class="mdi mdi-account-group"></i><span> {{ restaurant.visitCount }}</span>
        </div>
        <div>
          <i class="mdi mdi-file"></i><span> {{ restaurant.reportCount }}</span>
        </div>
      </div>
    </div>
  </RouterLink>
</template>


<script>
import { RouterLink } from 'vue-router';
import { Restaurant } from '../models/Restaurant.js';

export default {
    props: { restaurant: { type: Restaurant, required: true } },
    setup() {
        return {};
    },
    components: { RouterLink }
}
</script>


<style lang="scss" scoped>
.card-img{
  height: 20vh;
  object-fit: cover;
  object-position: center;
}
</style>
