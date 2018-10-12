<template>
  <div class="userKeeps">
    <h1>Your Keeps</h1>
    <!-- <div class="keepCard" v-if="keep.isPrivate == 0"> -->
    <div v-for="keep in keepsById" :key="keepsById.id">
      <img :src="keep.img" class="keepCard" alt="keep.name">
      <p>Title: {{keep.name}}</p>
      <p>Description: {{keep.description}}</p>
      <p>Views: {{keep.views}}</p>
      <p>Keeps: {{keep.keeps}}</p>
      <p>Shares: {{keep.shares}}</p>
    </div>
  </div>
  </div>
  <!-- reference Vue-Music for this card -->
</template>

<script>
  export default {
    name: "userKeeps",
    computed: {
      keepsById() {
        return this.$store.state.keepsById;
      }
    }
  };
</script>

<style>
</style>