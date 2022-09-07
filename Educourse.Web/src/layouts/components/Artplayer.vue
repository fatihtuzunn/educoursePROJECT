<template>
  <div ref="artRef"></div>
</template>
<script>
import Artplayer from "artplayer";
export default {
  data() {
    return {
      instance: null,
    };
  },
  props: {
    option: {
      type: Object,
      
    },
  },
  methods:{

  },
  mounted() {
    this.instance = new Artplayer({
      ...this.option,
      container: this.$refs.artRef,
    });
    this.$nextTick(() => {
      this.$emit("get-instance", this.instance);
      this.$emit("currTime", this.instance);
      this.$emit('seekTime', this.instance);
    });
  },
  beforeUnmount() {
    if (this.instance && this.instance.destroy) {
      this.instance.destroy(false);
    }
  },
};
</script>