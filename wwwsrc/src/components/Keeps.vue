<template>
  <div class="generalKeeps">
    <h1>Keeps</h1>
    <div class="keepCard" v-if="keep.isPrivate == 0">
      <div v-for="keep in keeps" :key="keep.id">
        <img :src="keep.img" class="keepCard" alt="keep.name">
        <p>Title: {{keep.title}}</p>
        <p>Description: {{keep.description}}</p>
      </div>
    </div>
  </div>
  <!-- reference Vue-Music for this card -->
</template>

<script>
  export default {
    computed: {
      keeps() {
        return this.$store.state.keeps;
      }
    }
  };
</script>

<style>
</style>