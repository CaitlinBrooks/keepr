<template>
  <div class="vault">
    <h1>{{vault.name}}</h1>
    <div v-for="keep in keeps" :key="keep.id">
      <img :src="keep.img" class="keepCard" alt="keep.name" style="width:200px;height:200px;">
      <p>{{keep.name}}</p>
      <p>{{keep.description}}</p>
      <button @click="deleteVaultKeep">Delete</button>
    </div>
  </div>
  </div>
  <!-- referenced Vue-Music for this card -->
</template>

<script>
  export default {
    name: "vault",
    data() {
      return {
      }
    },
    computed: {
      vault() {
        return this.$store.state.currentVault
      },
      keeps() {
        return this.$store.state.vaultKeeps
      }
    },
    mounted() {
      this.store.dispatch("getVault", this.$route.params.vaultId)
      this.store.dispatch("getVaultKeeps", this.$route.params.vaultId)
    },
    methods: {
      deleteVaultKeep(keep) {
        let vaultkeep = {
          keepId: keep.Id,
          vaultId: this.vault.Id
        }
        this.$store.dispatch("deleteVaultKeep", vaultkeep);
      }
    },
  };
</script>

<style>
</style>