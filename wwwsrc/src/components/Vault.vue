<template>
  <div class="vault">
    <h1>{{vault.name}}</h1>
    <img src="../assets/KeeprLogonb.png" alt="Circle Keepr">
    <div v-for="keep in keeps" :key="keep.id">
      <img :src="keep.img" class="keepCard" alt="keep.name" style="width:200px;height:200px;">
      <p>{{keep.name}}</p>
      <p>{{keep.description}}</p>
      <button @click="deleteVaultKeep(keep)">Delete</button>
      <!-- deleteVaultKeep takes in a keep -->
    </div>
  </div>
  </div>
  <!-- referenced Vue-Music for this card -->
</template>

<script>
  export default {
    name: "vault",
    props: ["vaultId"],
    data() {
      return {
      }
    },
    computed: {
      vault() {
        return this.$store.state.currentVault
      },
      keeps() {
        return this.$store.state.vaultkeeps
      }
    },
    mounted() {
      this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId)
    },
    methods: {
      deleteVaultKeep(keep) {
        let vaultkeep = {
          keepId: keep.id,
          vaultId: this.vaultId
        }
        this.$store.dispatch("deleteVaultKeep", vaultkeep);
      }
    },
  };
</script>

<style>
</style>