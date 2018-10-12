<template>
  <div class="publicKeeps">
    <h1>Public Keeps</h1>
    <div class="row" v-for="keep in keeps" :key="keep.id">
      <div class="col-12">
        <div class="keepCard" v-if="keep.isPrivate == 0">
          <img :src="keep.img" class="keepCard" alt="keep.name" style="width:200px;height:200px;">
          <!-- <p>{{keep.name}}</p> -->
          <!-- <p>{{keep.description}}</p> -->
        </div>
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