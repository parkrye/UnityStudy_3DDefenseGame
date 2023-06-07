public class InfoSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        texts["hpText"].text = "20".ToString();
        texts["coinText"].text = "100".ToString();

    }
}
