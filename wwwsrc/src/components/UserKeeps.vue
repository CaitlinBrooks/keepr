<template>
  <div class="userKeeps">
    <h1>Your Keeps</h1>
    <!-- <div class="keepCard" v-if="keep.isPrivate == 0"> -->
    <button type="submit">Create Keep</button>
    <div v-for="keep in keepsById" :key="keepsById.id">
      <img :src="keep.img" class="keepCard" alt="keep.name" style="width:200px;height:200px;">
      <button type="submit">Delete Keep</button>
      <button type="submit">Add to Vault</button>
      <!-- <p>Views: {{keep.views}}</p>
      <p>Keeps: {{keep.keeps}}</p>
      <p>Shares: {{keep.shares}}</p> -->
    </div>
  </div>
  </div>
  <!-- reference Vue-Music for this card -->
</template>

<script>
  export default {
    name: "userKeeps",
    data() {
      return {
        newKeep: {

        }
      }
    },
    computed: {
      keepsById() {
        return this.$store.state.keepsById;
      },
      getAllVaults() {
        return this.$store.state.vaults;
      },
      methods: {
        newKeep() {
          this.$store.dispatch("newKeep", this.newKeep);

        },
        deleteKeep(keep) {
          this.$store.dispatch("deleteKeep", keep);
        },
        moveKeepToVault() {
          // this.vaultKeep.keepId = this. -- am I on the right track?
        }
      }
    }
  };
</script>

<style>
</style>