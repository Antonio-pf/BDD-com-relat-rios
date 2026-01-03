using System;
using System.Diagnostics;
using Allure.Net.Commons;
using Reqnroll;

namespace Calculator.Test.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Debug.WriteLine(nameof(BeforeTestRun));
            
            // Configure Allure results directory
            Environment.SetEnvironmentVariable("ALLURE_RESULTS_DIRECTORY", "allure-results");
            
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            Debug.WriteLine(context.FeatureInfo.Description);
            Debug.WriteLine(nameof(BeforeFeature));
        }

        [AfterFeature]
        public static void AfterFeature()
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var testResult = new TestResult
            {
                uuid = Guid.NewGuid().ToString(),
                name = _scenarioContext.ScenarioInfo.Title,
                fullName = $"{_featureContext.FeatureInfo.Title}.{_scenarioContext.ScenarioInfo.Title}",
                labels = new System.Collections.Generic.List<Label>
                {
                    new Label { name = "feature", value = _featureContext.FeatureInfo.Title },
                    new Label { name = "suite", value = _featureContext.FeatureInfo.Title }
                }
            };

            foreach (var tag in _scenarioContext.ScenarioInfo.Tags)
            {
                testResult.labels.Add(new Label { name = "tag", value = tag });
            }

            AllureLifecycle.Instance.StartTestCase(testResult);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                AllureLifecycle.Instance.UpdateTestCase(x => x.status = Status.failed);
                AllureLifecycle.Instance.UpdateTestCase(x => x.statusDetails = new StatusDetails
                {
                    message = _scenarioContext.TestError.Message,
                    trace = _scenarioContext.TestError.StackTrace
                });
            }
            else
            {
                AllureLifecycle.Instance.UpdateTestCase(x => x.status = Status.passed);
            }

            AllureLifecycle.Instance.StopTestCase();
            AllureLifecycle.Instance.WriteTestCase();
        }

        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {

        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {

        }

        [BeforeStep]
        public void BeforeStep()
        {
            var stepInfo = _scenarioContext.StepContext.StepInfo;
            var stepResult = new StepResult
            {
                name = $"{stepInfo.StepDefinitionType} {stepInfo.Text}"
            };

            AllureLifecycle.Instance.StartStep(stepResult);
        }

        [AfterStep]
        public void AfterStep()
        {
            if (_scenarioContext.TestError != null)
            {
                AllureLifecycle.Instance.UpdateStep(x => x.status = Status.failed);
            }
            else
            {
                AllureLifecycle.Instance.UpdateStep(x => x.status = Status.passed);
            }

            AllureLifecycle.Instance.StopStep();
        }
    }
}
